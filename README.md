# navigate-page-while-tap-listview-item-in-.net-maui
How to navigate a page while tapping .NET MAUI ListViewItem using MVVM ?

## Sample

```xaml
<listView:SfListView x:Name="list" ItemSize="70" ItemsSource="{Binding contactsinfo}" ItemSpacing="0,0,5,0" SelectionMode="Single">
    <listView:SfListView.ItemTemplate>
        <DataTemplate x:Name="ItemTemplate">
            <code>
            . . .
            . . .
            <code>
        </DataTemplate>
    </listView:SfListView.ItemTemplate>
</listView:SfListView>

DetailsPage:

<Grid Padding="0,10,5,0">
    <Grid.RowDefinitions>
        <RowDefinition Height="200" />
        <RowDefinition Height="30" />
        <RowDefinition Height="30" />
    </Grid.RowDefinitions>
    <Image Source="{Binding ContactImage}"
        VerticalOptions="Center"
        HorizontalOptions="Center"
        HeightRequest="200"
        Grid.Row="0"/>
    <Label LineBreakMode="NoWrap"
        TextColor="#474747"
        Text="{Binding ContactName}" Grid.Row="1" FontSize="20" HorizontalTextAlignment="Center" />
    <Label Grid.Row="2"
        TextColor="#474747"
        LineBreakMode="NoWrap"
        Text="{Binding ContactNumber}" FontSize="20" HorizontalTextAlignment="Center" />
</Grid>

ViewModel.cs:

private Command<object> tapCommand;
private INavigation navigation;

public Command<object> TapCommand
{
    get { return tapCommand; }
    set { tapCommand = value; }
}
public INavigation Navigation
{
    get { return navigation; }
    set { navigation = value; }
}

tapCommand = new Command<object>(OnTapped);

private void OnTapped(object obj)
{
    var newPage = new DetailsPage();
    newPage.BindingContext = obj;
    Navigation.PushAsync(newPage);
}
```
