using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine(String.Format("{0}\"R\":{1},\"G\":{2},\"B\":{3}{4}", "{", 100, 200, 300,"}"));
            Console.WriteLine(String.Format("L{0,3:D3}{1,3:D3}{2,3:D3}", 100, 10, 1));
            

            // (1) 소켓 객체 생성 (TCP 소켓)
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
 
            // (2) 서버에 연결
            var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
            while(true){
                while(true){
                    try{
                        Console.WriteLine("connecting...");
                        var result = sock.BeginConnect(ep, null, null);
                        bool success = result.AsyncWaitHandle.WaitOne(5000, true);
                        if (success) {
                            sock.EndConnect(result);
                            break;
                        }
                        else { 
                            sock.Close();
                            throw new SocketException(10060); // Connection timed out. 
                        }

                    }
                    catch(SocketException e){
                        //sock.Close();
                        Console.WriteLine(e);
                        Console.WriteLine("failed");
                       //Task.Delay(TimeSpan.FromSeconds(1));
                        //sock.Close();    
                    
                    }
                    catch(ObjectDisposedException e){
                        Console.WriteLine(e.ToString());
                    }
                }

                try{
                    
                    

                    string cmd = string.Empty;
                    byte[] receiverBuff = new byte[10];
        
                    Console.WriteLine("Connected... Enter 'disconn' to exit");
        
                    while (true)
                    {
                        cmd = Console.ReadLine();
                        byte[] buff = Encoding.UTF8.GetBytes(cmd);
                    
                        // (3) 서버에 데이타 전송
                        sock.Send(buff, SocketFlags.None);

                        // (4) 서버에서 데이타 수신
                        int n = sock.Receive(receiverBuff);
        
                        string data = Encoding.UTF8.GetString(receiverBuff, 0, n);
                        Console.WriteLine(data);

                        if(cmd == "disconn") break;
                    }
        
                    // (5) 소켓 닫기
                    //sock.Close();
                }
                catch(ObjectDisposedException){
                    //Console.WriteLine(e);
                    Console.WriteLine("error1");
                    sock.Disconnect(true);
                    //while(true);
                }
                catch(SocketException){
                    //Console.WriteLine(e);
                    sock.Disconnect(true);
                    //while(true);
                }
                
            }
        }
    }
}
