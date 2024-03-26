namespace Radio.FM.Data;

public class HttpData : HttpClient
{
    private string _url => @"https://radios.vpn.sapo.pt/";
    public HttpData() : base()
    {
        try
        {
            BaseAddress = new Uri(_url);
            DefaultRequestHeaders.Add("Accept", "application/json");
        }
        catch (Exception ex)
        {
            _ = App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
