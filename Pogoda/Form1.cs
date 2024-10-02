using System.Text.Json;

namespace Pogoda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Current
        {
            public string time { get; set; }
            public int interval { get; set; }
            public double temperature_2m { get; set; }
            public int relative_humidity_2m { get; set; }
            public int weather_code { get; set; }
        }

        public class CurrentUnits
        {
            public string time { get; set; }
            public string interval { get; set; }
            public string temperature_2m { get; set; }
            public string relative_humidity_2m { get; set; }
            public string weather_code { get; set; }
        }

        public class Root
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public double generationtime_ms { get; set; }
            public int utc_offset_seconds { get; set; }
            public string timezone { get; set; }
            public string timezone_abbreviation { get; set; }
            public double elevation { get; set; }
            public CurrentUnits current_units { get; set; }
            public Current current { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast?latitude=54.36&longitude=18.64&current=temperature_2m,relative_humidity_2m,weather_code");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            Current? weatherForecast = JsonSerializer.Deserialize<Current>(result);

            richTextBox1.Text = $"Temperature: {weatherForecast?.temperature_2m}°C, Humidity: {weatherForecast?.relative_humidity_2m}%, Weather Code: {weatherForecast?.weather_code}";
        }
    }
}