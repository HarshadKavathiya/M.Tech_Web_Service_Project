using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = " ";
        Label2.Text = " ";
        Label3.Text = " ";
        Label4.Text = " ";
        Label5.Text = " ";
        Label6.Text = " ";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Domain_URL = TextBox1.Text;
        var client = new Service1Client();
        Double alexaval=0.0,googlePRval=0.0,result=0.0;
        string display_result; 
        int Alexa_Rank = client.alexaRankCount(Domain_URL);
        int PageRank = client.GooglePageRankCount(Domain_URL);
        Label1.Text = Alexa_Rank.ToString();
        Label2.Text = PageRank.ToString();

        if (Alexa_Rank >= 3000000 || Alexa_Rank==-1)
        {
            alexaval = -1.0;
        }
        else if (Alexa_Rank >= 2000000 && Alexa_Rank <= 3000000)
        {
            alexaval = -0.5;
        }else if (Alexa_Rank >= 1000000 && Alexa_Rank <= 2000000)
        {
            alexaval = -0.25;
        }
        else if (Alexa_Rank >= 500000 && Alexa_Rank <= 1000000)
        {
            alexaval = 0.25;
        }
        else if (Alexa_Rank >= 300000 && Alexa_Rank <= 500000)
        {
            alexaval = 0.5;
        }
        else if(Alexa_Rank<=300000)
        {
            alexaval = 1.0;
        }

        if (PageRank <=0)
        {
            googlePRval = -1.0;
        }
        else if (PageRank <=2)
        {
            googlePRval = -0.5;
        }else if (PageRank <=4)
        {
            googlePRval = -0.25;
        }else if (PageRank <=6)
        {
            googlePRval = 0.25;
        }else if (PageRank <=8)
        {
            googlePRval = 0.5;
        }else if (PageRank<=10)
        {
            googlePRval = 1.0;
        }

        result = (alexaval + googlePRval)/2;
       
        
        if(result<=-0.40)
        {
            display_result = "Given Website " + Domain_URL + " may Not be safe";
        }
        else if (result >= 0.25)
        {
            display_result = "Given Website " + Domain_URL + " is safe";
        }
        else
        {
            display_result = "We are not able to determine wheather " + Domain_URL + " is phishing website or not...";
        
        }
        Label3.Text = Convert.ToString(alexaval);
        Label4.Text = Convert.ToString(googlePRval);
        Label5.Text = Convert.ToString(result);
        Label6.Text = display_result;        
    }
    
}