# How to navigate a page while tapping .NET MAUI ListView's item using MVVM?

The [.NET MAUI ListView (SfListView)](https://www.syncfusion.com/maui-controls/maui-listview) allows you to navigate to another page when an element in the ***ListViewItem*** is tapped. This can be achieved by adding a [GestureRecognizer](https://docs.microsoft.com/en-us/dotnet/maui/fundamentals/gestures/tap) to that element in the ***ItemTemplate***.

XAML

Add *TapGestureRecognizer* to the ***Image*** and bind the ***Command*** to navigate to a page when the image is tapped from the ***ViewModel***.
<ContentPage.Content>
            <Grid>
                <listView:SfListView x:Name="list" ItemSize="70" ItemsSource="{Binding contactsinfo}" ItemSpacing="0,0,5,0" SelectionMode="Single">
                    <listView:SfListView.ItemTemplate>
                        <DataTemplate x:Name="ItemTemplate">
                            <ViewCell>
                                <ViewCell.View>
                                    <Grid x:Name="grid" RowSpacing="1">
                                        <Grid.RowDefinitions>
                                            <RowDefinition Height="*" />
                                            <RowDefinition Height="1" />
                                        </Grid.RowDefinitions>
                                        <Grid RowSpacing="1" Padding="10,0,0,0">
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="50" />
                                                <ColumnDefinition Width="*" />
                                                <ColumnDefinition Width="*" />
                                            </Grid.ColumnDefinitions>
                                            <Image Source="{Binding ContactImage}"
                               VerticalOptions="Center"
                               HorizontalOptions="Center"
                               HeightRequest="50"/>
                                            <Grid Grid.Column="1"
                              RowSpacing="1"
                              Padding="10,0,0,0"
                              VerticalOptions="Center">
                                                <Grid.RowDefinitions>
                                                    <RowDefinition Height="*" />
                                                    <RowDefinition Height="*" />
                                                </Grid.RowDefinitions>
                                                <Label LineBreakMode="NoWrap"
                                 TextColor="#474747"
                                 Text="{Binding ContactName}"
                                                       FontSize="12">
     
                                                </Label>
                                                <Label Grid.Row="1"
                                 Grid.Column="0"
                                 TextColor="#474747"
                                 LineBreakMode="NoWrap"
                                 Text="{Binding ContactNumber}"
                                                       FontSize="12">
     
                                                </Label>
                                            </Grid>
                                            <Grid Grid.Row="0"
                              x:Name="temp"
                              Grid.Column="2"
                              RowSpacing="0"
                              HorizontalOptions="End"
                              Padding="0,10,10,0">
                                                <Image Source="navigate.png">
                                                    <Image.GestureRecognizers>
                                                        <TapGestureRecognizer
                                  Command="{Binding Path=BindingContext.TapCommand, Source = {x:Reference list}}" CommandParameter="{Binding}" />
                                                    </Image.GestureRecognizers>
                                                </Image>
                                            </Grid>
                                        </Grid>
                                        <StackLayout Grid.Row="1" BackgroundColor="#E4E4E4" HeightRequest="1"/>
                                    </Grid>
                                </ViewCell.View>
                            </ViewCell>
                        </DataTemplate>
                    </listView:SfListView.ItemTemplate>
                </listView:SfListView>
            </Grid>
        </ContentPage.Content>
C#

In the ViewModel, navigate to another page using the INavigation interface when the tap command is invoked.

public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields
    
        private Command<object> tapCommand;
        private INavigation navigation;
    
        #endregion
    
        #region Properties
    
        public ObservableCollection<Contacts> contactsinfo { get; set; }
    
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
    
        #endregion
    
        #region Constructor
    
        public ContactsViewModel(INavigation _navigation)
        {
            navigation = _navigation;
            tapCommand = new Command<object>(OnTapped);
        }
    
        private async void OnTapped(object obj)
        {
            var newPage = new Page1();
            newPage.BindingContext = obj;
            await Navigation.PushAsync(newPage);
        }
    
        #endregion
    
        public event PropertyChangedEventHandler PropertyChanged;
    }

**Output**

![Navigate from one page to another by tapping the listview item](https://www.syncfusion.com/uploads/user/kb/maui/maui-2738/maui-2738_img1.gif)

Download the complete sample on [GitHub](https://github.com/SyncfusionExamples/navigate-page-while-tap-listview-item-in-.net-maui)

**Conclusion**

I
hope you enjoyed how to navigate to a
page while tapping on a .NET MAUI ListView's item using MVVM (SfListView).

You
can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to learn about its other groundbreaking feature
representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started),
and how to quickly get started with configuration specifications. You can also
explore our [.NET MAUI ListView example](https://github.com/syncfusion/maui-demos/tree/master/MAUI/ListView) to understand how to
create and manipulate data. You can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense "https://www.syncfusion.com/sales/teamlicense") page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui)
to check out our other controls. Please let us know in the comments section below if you have any queries or require clarification. Contact us through our [support
forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback
portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
