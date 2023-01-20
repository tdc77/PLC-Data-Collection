using System;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DataCollectionMinth
{
    internal class EMAIL : Form1
    {


        public void SendMail()
        {
            try
            {
                //// Create the Outlook application by using inline initialization.
                Outlook.Application oApp = new Outlook.Application();

                ////Create the new message by using the simplest approach.
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                //Add a recipient.
                // TODO: Change the following recipient where appropriate.
                Outlook.Recipients oRecips = oMsg.Recipients;
                List<string> oTORecip = new List<string>();
                List<string> oCCRecip = new List<string>();

                oTORecip.Add("tyler.wohjan@minthgroup.com");
                oCCRecip.Add("terry.carlisle@minthgroup.com");
                oCCRecip.Add("brian.janego@minthgroup.com");
                foreach (string t in oTORecip)
                {
                    Outlook.Recipient oTORecipt = oRecips.Add(t);
                    oTORecipt.Type = (int)Outlook.OlMailRecipientType.olTo;
                    oTORecipt.Resolve();
                }

                foreach (string t in oCCRecip)
                {
                    Outlook.Recipient oCCRecipt = oRecips.Add(t);
                    oCCRecipt.Type = (int)Outlook.OlMailRecipientType.olCC;
                    oCCRecipt.Resolve();
                }
                // DateTime.Now.ToString("yyyyMMdd")
                //Set the basic properties.
                oMsg.Subject = "WL74 Mail- " + DateTime.Today.ToString("MM/dd/yyyy");
                oMsg.HTMLBody = "<html>" +
                    "<head>" +
                    "<title>WL74 Automated Mail</title>" +
                    "</head>" +
                    "<body style='background-color:#E6E6E6;'>" +
                    "<div style='font-family: Georgia, Arial; font-size:14px; '>Hi All,<br /><br />"
                     +
                    "This is from WL74. Please see my production today!!." +
                    "Files can be found on WL74 Dynics PC @C:\\Users\\Public\\Minth\\DataCollection<br /><br /><br /><br /><br />" +
                    "Thanks & Regards<br />" +
                    "WL74 Automted response" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                string date = DateTime.Today.ToString("MM-dd-yyyy");

                //Add an attachment.
                // TODO: change file path where appropriate
                
                if (shift1EmailReady == 1)
                {
                    String sSource = @"C:\\Users\\Public\\Minth\\DataCollection\\" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx"; // find file on pc
                    String sDisplayName = "WL74 Production First Shift"; //name of attachment
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);
                    // If you want to, display the message.
                    // oMsg.Display(true);  //modal

                    //Send the message.
                    oMsg.Save();
                    oMsg.Send();

                    //Explicitly release objects.
                    oTORecip = null;
                    oCCRecip = null;
                    oAttach = null;
                    oMsg = null;
                    oApp = null;

                   
                    GC.Collect();//garbage collect
                }
                 if(shift2EmailReady == 1)
                {
                    String sSource = @"C:\\Users\\Public\\Minth\\DataCollection\\" + DateTime.Today.AddDays(-1).ToString("yyyyMMdd_2") +".xlsx"; // find file on pc remember its now yesterday!!
                    String sDisplayName = "WL74 Production Second Shift"; //name of attachment
                    int iPosition = (int)oMsg.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);
                    // If you want to, display the message.
                    // oMsg.Display(true);  //modal

                    //Send the message.
                    oMsg.Save();
                    oMsg.Send();

                    //Explicitly release objects.
                    oTORecip = null;
                    oCCRecip = null;
                    oAttach = null;
                    oMsg = null;
                    oApp = null;

                    GC.Collect();//garbage collect
                }
                
            }

            catch (Exception)
            {
                TimedMessageBox.Show("Cannot connect to email or no sheet found", "ERROR", 5000);
                return;

            }
        }

        private void InitializeComponent()
        {
           
            this.SuspendLayout();
            // 
            // OEEChart
            // 
            
            // 
            // EMAIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EMAIL";
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
