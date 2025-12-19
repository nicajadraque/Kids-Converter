using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnitsNet;
using UnitsNet.Units;
using static Kids_Converter.MVVM.Models.Measurement;

public class ConverterViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public ObservableCollection<string> FromMeasures { get; } = new();
    public ObservableCollection<string> ToMeasures { get; } = new();

    private string _fromUnit;
    public string CurrentFromMeasure
    {
        get => _fromUnit;
        set { _fromUnit = value; OnPropertyChanged(); Convert(); }
    }

    private string _toUnit;
    public string CurrentToMeasure
    {
        get => _toUnit;
        set { _toUnit = value; OnPropertyChanged(); Convert(); }
    }

    private string _fromValue = "1"; // make it string for Entry
    public string FromValue
    {
        get => _fromValue;
        set { _fromValue = value; OnPropertyChanged(); Convert(); }
    }

    private double _toValue;
    public double ToValue
    {
        get => _toValue;
        set { _toValue = value; OnPropertyChanged(); }
    }



    private readonly MeasurementCategory _category;

    public ConverterViewModel(MeasurementCategory category)
    {
        _category = category;
        LoadUnits();
    }

    void LoadUnits()
    {
        FromMeasures.Clear();
        ToMeasures.Clear();

        IEnumerable<string> units = _category switch
        {
            MeasurementCategory.Information => Enum.GetNames(typeof(InformationUnit)),
            MeasurementCategory.Volume => Enum.GetNames(typeof(VolumeUnit)),
            MeasurementCategory.Length => Enum.GetNames(typeof(LengthUnit)),
            MeasurementCategory.Mass => Enum.GetNames(typeof(MassUnit)),
            MeasurementCategory.Temperature => Enum.GetNames(typeof(TemperatureUnit)),
            MeasurementCategory.Energy => Enum.GetNames(typeof(EnergyUnit)),
            MeasurementCategory.Area => Enum.GetNames(typeof(AreaUnit)),
            MeasurementCategory.Speed => Enum.GetNames(typeof(SpeedUnit)),
            MeasurementCategory.Duration => Enum.GetNames(typeof(DurationUnit)),
            _ => Enumerable.Empty<string>()
        };

        foreach (var u in units)
        {
            FromMeasures.Add(u);
            ToMeasures.Add(u);
        }

        CurrentFromMeasure = FromMeasures.FirstOrDefault();
        CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
    }

    public void Convert()
    {
        if (CurrentFromMeasure == null || CurrentToMeasure == null)
            return;

        if (!double.TryParse(FromValue, out double input))
        {
            ToValue = 0;
            return;
        }

        ToValue = _category switch
        {
            MeasurementCategory.Information =>
                (double)Information.From(input, Enum.Parse<InformationUnit>(CurrentFromMeasure))
                                   .As(Enum.Parse<InformationUnit>(CurrentToMeasure)),

            MeasurementCategory.Volume =>
                Volume.From(input, Enum.Parse<VolumeUnit>(CurrentFromMeasure))
                      .As(Enum.Parse<VolumeUnit>(CurrentToMeasure)),

            MeasurementCategory.Length =>
                Length.From(input, Enum.Parse<LengthUnit>(CurrentFromMeasure))
                      .As(Enum.Parse<LengthUnit>(CurrentToMeasure)),

            MeasurementCategory.Mass =>
                Mass.From(input, Enum.Parse<MassUnit>(CurrentFromMeasure))
                    .As(Enum.Parse<MassUnit>(CurrentToMeasure)),

            MeasurementCategory.Temperature =>
                Temperature.From(input, Enum.Parse<TemperatureUnit>(CurrentFromMeasure))
                           .As(Enum.Parse<TemperatureUnit>(CurrentToMeasure)),

            MeasurementCategory.Energy =>
                Energy.From(input, Enum.Parse<EnergyUnit>(CurrentFromMeasure))
                      .As(Enum.Parse<EnergyUnit>(CurrentToMeasure)),

            MeasurementCategory.Area =>
                Area.From(input, Enum.Parse<AreaUnit>(CurrentFromMeasure))
                    .As(Enum.Parse<AreaUnit>(CurrentToMeasure)),

            MeasurementCategory.Speed =>
                Speed.From(input, Enum.Parse<SpeedUnit>(CurrentFromMeasure))
                     .As(Enum.Parse<SpeedUnit>(CurrentToMeasure)),

            MeasurementCategory.Duration =>
                Duration.From(input, Enum.Parse<DurationUnit>(CurrentFromMeasure))
                        .As(Enum.Parse<DurationUnit>(CurrentToMeasure)),

            _ => 0
        };

    }
}
