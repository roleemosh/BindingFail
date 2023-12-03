using System.Windows.Input;

namespace BindingFail.UserControls;

public partial class FieldTag : Frame
{
    private WeakEventManager _weakEventManager;
    public FieldTag()
    {
        _weakEventManager = new WeakEventManager();
        InitializeComponent();
    }

    public double FontSize
    #region
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    public static BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize), typeof(double), typeof(FieldTag), 16.0);
    #endregion

    public Color TextColor
    #region
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    public static BindableProperty TextColorProperty = BindableProperty.Create(
      nameof(TextColor), typeof(Color), typeof(FieldTag), Colors.Black);
    #endregion

    public string Text
    #region
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(FieldTag), string.Empty);
    #endregion

    public bool IsChecked
    #region
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public static BindableProperty IsCheckedProperty = BindableProperty.Create(
      nameof(IsChecked), typeof(bool), typeof(FieldTag), false, propertyChanged: OnIsCheckedChanged);

    private static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        FieldTag @this = bindable as FieldTag;
        bool casted = (bool)newValue;
        @this.BackgroundColor = casted ? @this.IsCheckedBackgroundColor : @this.IsUnCheckedBackgroundColor;
        if (casted)
        {
            @this.CallOnIsCheckChanged(newValue);
            @this.CheckedCommand?.Execute(@this.CheckedCommandParameter);
        }
    }

    #endregion

    public ICommand CheckedCommand
    #region
    {
        get => (ICommand)GetValue(CheckedCommandProperty);
        set => SetValue(CheckedCommandProperty, value);
    }

    public static BindableProperty CheckedCommandProperty = BindableProperty.Create(
        nameof(CheckedCommand), typeof(ICommand), typeof(FieldTag), null);
    #endregion

    public object CheckedCommandParameter
    #region
    {
        get => (object)GetValue(CheckedCommandParameterProperty);
        set => SetValue(CheckedCommandParameterProperty, value);
    }

    public static BindableProperty CheckedCommandParameterProperty = BindableProperty.Create(
        nameof(CheckedCommandParameter), typeof(object), typeof(FieldTag), null);
    #endregion

    public event EventHandler IsCheckedChanged
    #region
    {
        add => _weakEventManager.AddEventHandler(value);
        remove => _weakEventManager.RemoveEventHandler(value);
    }
    private void CallOnIsCheckChanged(object value)
    {
        _weakEventManager.HandleEvent(this, value, nameof(IsCheckedChanged));
    }

    #endregion

    public static BindableProperty IsCheckedBackgroundColorProperty
    #region
        = BindableProperty.Create(
        nameof(IsCheckedBackgroundColor), typeof(Color), typeof(FieldTag), Colors.Blue, propertyChanged: OnIsCheckedBackgroundColorPropertyChanged);

    public Color IsCheckedBackgroundColor
    {
        get => (Color)GetValue(IsCheckedBackgroundColorProperty);
        set => SetValue(IsCheckedBackgroundColorProperty, value);
    }

    private static void OnIsCheckedBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        FieldTag @this = bindable as FieldTag;
        @this.BackgroundColor = @this.IsChecked ? (Color)newValue : @this.IsUnCheckedBackgroundColor;
    }
    #endregion

    public static BindableProperty IsUnCheckedBackgroundColorProperty
    #region
      = BindableProperty.Create(
      nameof(IsUnCheckedBackgroundColor), typeof(Color), typeof(FieldTag), Colors.Transparent, propertyChanged: OnIsUnCheckedBackgroundColorPropertyChanged);

    public Color IsUnCheckedBackgroundColor
    {
        get => (Color)GetValue(IsUnCheckedBackgroundColorProperty);
        set => SetValue(IsUnCheckedBackgroundColorProperty, value);
    }
    private static void OnIsUnCheckedBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        FieldTag @this = bindable as FieldTag;
        @this.BackgroundColor = @this.IsChecked ? @this.IsCheckedBackgroundColor : (Color)newValue;
    }
    #endregion

    private void OnControlTapped(object sender, TappedEventArgs e)
    {
        IsChecked = !IsChecked;
    }
}