using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;
using System;

public class SendProcessed : MonoBehaviour {

    bool triggerResultEmail= false;
    bool resultEmailSucess;

	[SerializeField] string SMTPClient;
	[SerializeField] string SMTPPort;
	[SerializeField] string UserName;
	[SerializeField] string UserPass;
	[SerializeField] string To;
	[SerializeField] string Subject;
	[SerializeField] string Body;
	[SerializeField] string AttachFile;

	public void init(){
		SMTPClient = SendXml.temp_client;
		SMTPPort = SendXml.temp_port;
		UserName = SendXml.temp_user;
		UserPass = SendXml.temp_pass;

		To =  SendXml.temp_to;
		Subject = SendXml.temp_subject;
		Body = SendXml.temp_body;
		AttachFile = SendXml.temp_fileloc;

	}

	public void sendEmail(string to, string fileloc)
    {
		To = to;
		AttachFile = fileloc;

        SimpleEmailSender.emailSettings.STMPClient = SMTPClient.Trim();
        SimpleEmailSender.emailSettings.SMTPPort = Int32.Parse(SMTPPort.Trim());
        SimpleEmailSender.emailSettings.UserName = UserName.Trim();
        SimpleEmailSender.emailSettings.UserPass = UserPass.Trim();

        SimpleEmailSender.Send(To, Subject, Body, AttachFile, SendCompletedCallback);
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled || e.Error != null)
        {
            print("Email not sent: " + e.Error.ToString());

            resultEmailSucess = false;
            triggerResultEmail = true;
        }
        else
        {
            print("Email successfully sent.");

            resultEmailSucess = true;
            triggerResultEmail = true;
        }
    }
}
