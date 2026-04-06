namespace volonteer_center
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if(formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formEvents = new FormEvents(
                            formLogin.CurrentUser,
                            formLogin.IsGuest))
                        {
                            if(formEvents.ShowDialog() == DialogResult.OK)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}