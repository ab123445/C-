using WinFormsApp1;

namespace ChattingClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Rooms()); //room에서 Login이, formBase가 켜지게 바꿔야 함.


        }
    }
}