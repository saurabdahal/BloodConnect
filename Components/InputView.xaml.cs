namespace BloodConnect.Components;

public partial class InputView : ContentView
{
    public InputView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty GlyphProperty =
            BindableProperty.Create(nameof(Glyph), typeof(string), typeof(InputView), default(string)
                );

    public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(InputView), default(string));

    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(InputView), default(string));

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, "&#x" + value + ";");
    }

    public string PlaceHolder
    {
        get => (string)GetValue(PlaceHolderProperty);
        set => SetValue(PlaceHolderProperty, value);
    }

    public string Text
    {
        get => (string) GetValue(TextProperty);
        set => SetValue (TextProperty, value);
    }

}