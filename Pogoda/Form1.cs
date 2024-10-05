using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

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
        //refresh
        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");
                string url = "?" +
                             "latitude=54.36&" +
                             "longitude=18.64&" +
                             "current=temperature_2m,relative_humidity_2m,weather_code";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                Root? weatherForecast = JsonSerializer.Deserialize<Root>(result);

                if (weatherForecast?.current != null)
                {
                    string[] Separate = weatherForecast.current.time.Split('T');
                    string apiTime = Separate[1];
                    string summary;
                    switch (weatherForecast.current.weather_code)
                    {
                        case 0:
                            summary = "Clear Sky";
                            break;
                        case 1:
                            summary = "Mainly clear";
                            break;
                        case 2:
                            summary = "Partly cloudy";
                            break;
                        case 3:
                            summary = "Overcast";
                            break;
                        case 45:
                            summary = "Fog";
                            break;
                        case 48:
                            summary = "Depositing rime fog";
                            break;
                        case 51:
                            summary = "Light drizzle";
                            break;
                        case 53:
                            summary = "Moderate drizzle";
                            break;
                        case 55:
                            summary = "Dense drizzle";
                            break;
                        case 56:
                            summary = "Light freezing drizzle";
                            break;
                        case 57:
                            summary = "Heavy freezing drizzle";
                            break;
                        case 61:
                            summary = "Slight rain";
                            break;
                        case 63:
                            summary = "Moderate rain";
                            break;
                        case 65:
                            summary = "Heavy rain";
                            break;
                        case 66:
                            summary = "Light freezing rain";
                            break;
                        case 67:
                            summary = "Heavy freezing rain";
                            break;
                        case 71:
                            summary = "Slight snowfall";
                            break;
                        case 73:
                            summary = "Moderate snowfall";
                            break;
                        case 75:
                            summary = "Heavy snowfall";
                            break;
                        case 77:
                            summary = "Snow grains";
                            break;
                        case 80:
                            summary = "Slight rain shower";
                            break;
                        case 81:
                            summary = "Moderate rain shower";
                            break;
                        case 82:
                            summary = "Violent rain shower";
                            break;
                        case 85:
                            summary = "Slight snow shower";
                            break;
                        case 86:
                            summary = "Heavy snow shower";
                            break;
                        case 95:
                            summary = "Thunderstorm";
                            break;
                        case 96: case 99:
                            summary = "Thunderstorm with slight and heavy hail";
                            break;
                        default:
                            summary = "End of the World";
                            break;
                    }
                    label1.Text = $"Temperature: {weatherForecast.current.temperature_2m}°C";
                    label2.Text = $"Humidity: {weatherForecast.current.relative_humidity_2m}%";
                    label3.Text = $"Summary: {summary}";
                    label4.Text = $"Last api refresh: {apiTime}";

                }
                else
                {
                    label1.Text = "Error 404";
                    label2.Text = "Error 404";
                    label3.Text = "Error 404";
                    label4.Text = "Error 404";
                }
            }
        }
        //15 minutowy timer
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
