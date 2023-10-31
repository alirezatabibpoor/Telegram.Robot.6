using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Telegram.Robot._6;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //ALIREZA TABIBPOOR 
    //EXCERSICE 6 
    private static TelegramBotClient _client;
    static void Main(string[] args)
    {
        _client = new TelegramBotClient("6699487132:AAFTw3R4LPrmcU0qf3RRtx-JzYg0Csv-4QE");
        _client.OnMessage += Bot_OnMessage;
        _client.StartReceiving();
        Console.ReadKey();
    }

    private static void Bot_OnMessage(object? sender, Telegram.Bot.Args.MessageEventArgs e)
    {
        var text = e.Message.Text;
        var id = e.Message.Chat.Id;
        switch (text)
        {
            case "/hello":
                _client.SendTextMessageAsync(id, "hi");

                break;
            case "prayers":
                API c = new API();
                dataitem d = new dataitem();
                c.Main();

                _client.SendTextMessageAsync(id,d.result);
                break;






        }
    }
    public class API
    {
        public async void Main()
        {
            HttpClient client = new HttpClient();
            string str = "https://one-api.ir/owghat/?action=timestamp&token={token}&city={تهران}&timestamp={azan_sobh}&en_num={true}";
            HttpResponseMessage res = await client.GetAsync(str);
            if (res.IsSuccessStatusCode)
            {
                string apires = await res.Content.ReadAsStringAsync();
                Console.WriteLine(apires);
                Console.WriteLine();
                apiwrapper wrapper = new apiwrapper();

                wrapper = JsonConvert.DeserializeObject<apiwrapper>(apires);
                List<dataitem> datas = wrapper.datas;
                datas.Add(wrapper);

                Console.WriteLine(wrapper.result) ;




            }

        }
    }
    public class apiwrapper :dataitem
    {
        public List<dataitem> datas = new List<dataitem>();

       

    }




    public class dataitem:API
    {
        public string status { get; set; }
        public string result = "tehran" + "\n" + "azan_zohre = 12.56" + "\n" + "azan maqreb = 18.56";
        
        
           
            
        }
           
        }
    


    
        
            






        
    



       
    
    
    
    
        
    

   













