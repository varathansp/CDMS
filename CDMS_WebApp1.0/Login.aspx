<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CDMS_WebApp1._0.Login" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>eLog login page</title>

    <!-- Bootstrap -->
    <link href="css1/bootstrap.min.css" rel="stylesheet">
    <link href="css1/style.css" rel="stylesheet">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .block-margin-top
        {
            text-align: center;
        }
        .style1
        {
            border: 3px solid #FF0000;
            padding: 1px 4px;
            background-color: #FF0000;
        }
        .style3
        {
            height: 25px;
            position: absolute;
            left: 543px;
            top: 462px;
            width: 231px;
            text-align: center;
            right: 565px;
        }
        .style4
        {
            top: 299px;
            left: 538px;
            position: absolute;
            height: 31px;
            width: 232px;
        }
        .style5
        {
            top: 127px;
            left: 92px;
            position: absolute;
            height: 366px;
            width: 1158px;
            right: 83px;
            text-align: center;
        }
        .style6
        {
            top: 350px;
            left: 539px;
            position: absolute;
            height: 31px;
            width: 232px;
            right: 568px;
        }
        #form1
        {
            background-color: #003300;
            height: 604px;
        }
        </style>
  </head>
  <body style="border-style: solid; border-width: 8px; padding: 1px 4px; background-color: #336699; color: #FFFFFF;">
      <form id="form1" runat="server">
  <asp:Image ID="Image5" runat="server" 
    ImageUrl="~/CDMS_WebApp1.0/bin/Images/logo_new.JPG" CssClass="style5" 
          BorderWidth="3px" />
      <asp:TextBox ID="UserNameTextBox" placeholder="User Name" runat="server" 
          CssClass="style4"></asp:TextBox>
      <asp:TextBox ID="PasswordTextBox" placeholder="Password" runat="server" 
        TextMode="Password" CssClass="style6"></asp:TextBox>
      <asp:Panel ID="Panel1" runat="server" CssClass="style3">
          <asp:Label ID="LoginLabel" runat="server" CssClass="style1"></asp:Label>
      </asp:Panel>
          <asp:Button ID="Button1" runat="server" onclick="Button1_Click3" 
              style="top: 401px; left: 539px; position: absolute; height: 40px; width: 235px; color: #FFFFFF; background-color: #003300" 
              Text="Submit" CssClass="style7" />
      <asp:Panel ID="Panel2" runat="server" Height="568px" Width="882px">
          <asp:Panel ID="Panel3" runat="server" 
              style="top: 543px; left: 91px; position: absolute; height: 36px; width: 1165px">
              <asp:Label ID="Label1" runat="server" style="font-family: 'Britannic Bold'" 
                  Text="Developed By: HPU Team"></asp:Label>
          </asp:Panel>
          <asp:Panel ID="Panel4" runat="server" 
              style="top: 306px; left: 784px; position: absolute; height: 21px; width: 85px">
              <asp:Label ID="Label2" runat="server" style="color: #003366" 
                  Text="@npcil.co.in"></asp:Label>
          </asp:Panel>
      </asp:Panel>
      </form>

      </html>
