using Lines.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Lines.Models;

public class LineModel : INotifyPropertyChanged
{
    private int _xStart;
    private int _xEnd;
    private int _yStart;
    private int _yEnd;
    private SolidColorBrush _lineColor;
    private ObservableCollection<SolidColorBrush> _activeColors;

    private ICommand _updateEndPos;
    private ICommand _updateStartPos;

    public LineModel()
    {
        XStart = 50;
        YStart = 50;
        XEnd = 100;
        YEnd = 100;
        _activeColors = new()
        {
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.Green),
            new SolidColorBrush(Colors.Yellow),
            new SolidColorBrush(Colors.Black),
            new SolidColorBrush(Colors.Blue),
        };
        _lineColor = _activeColors[0];
    }

    public int XStart
    {
        get
        {
            return _xStart;
        }
        set
        {
            _xStart = value;
            OnPropertyChanged();
        }
    }
    public int XEnd
    {
        get
        {
            return _xEnd;
        }
        set
        {
            _xEnd = value;
            OnPropertyChanged();
        }
    }

    public int YStart
    {
        get
        {
            return _yStart;
        }
        set
        {
            _yStart = value;
            OnPropertyChanged();
        }
    }

    public int YEnd
    {
        get
        {
            return _yEnd;
        }
        set
        {
            _yEnd = value;
            OnPropertyChanged();
        }
    }

    public SolidColorBrush LineColor
    {
        get
        {
            return _lineColor;
        }
        set
        {
            _lineColor = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<SolidColorBrush> ActiveColors
    {
        get
        {
            return _activeColors;
        }
        set
        {
            _activeColors = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateEndPos
    {
        get
        {
            return _updateEndPos ??= new RelayCommand((obj) =>
                {
                    Point mousePosition = Mouse.GetPosition(null);
                    XEnd = (int)mousePosition.X;
                    YEnd = (int)mousePosition.Y;
                });
        }

    }

    public ICommand UpdateStartPos
    {
        get
        {
            return _updateStartPos ??= new RelayCommand((obj) =>
                {
                    Point mousePosition = Mouse.GetPosition(null);
                    XStart = (int)mousePosition.X;
                    YStart = (int)mousePosition.Y;
                });
        }

    }


    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
