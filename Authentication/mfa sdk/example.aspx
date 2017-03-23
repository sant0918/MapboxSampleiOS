<%@ Page Language="C#" AutoEventWireup="false" CodeFile="example.aspx.cs" Inherits="example" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr><td>Username:</td><td><asp:TextBox ID="txtUsername" runat="server" Text="test_user"></asp:TextBox></td></tr>
            <tr><td>Phone:</td><td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td></tr>
            <tr><td>Extension:</td><td><asp:TextBox ID="txtExtension" runat="server"></asp:TextBox></td></tr>
            <tr><td>Application Name:</td><td><asp:TextBox ID="txtApplicationName" runat="server"></asp:TextBox></td></tr>
            <tr><td>Device Token:</td><td><asp:TextBox ID="txtDeviceToken" runat="server"></asp:TextBox></td></tr>
            <tr><td>Notification Type:</td><td><asp:RadioButton ID="rbApns" runat="server" Text="APNS-iOS" GroupName="NotificationType" Checked="true" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbC2dm" runat="server" Text="C2DM-Android" GroupName="NotificationType" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbGcm" runat="server" Text="GCM-Android" GroupName="NotificationType" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbMpns" runat="server" Text="MPNS-Windows" GroupName="NotificationType" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbBps" runat="server" Text="BPS-Blackberry" GroupName="NotificationType" />
            </td></tr>
            <tr><td>Account Name:</td><td><asp:TextBox ID="txtAccountName" runat="server"></asp:TextBox></td></tr>
            <tr><td>Mode:</td><td>Voice Call: <asp:RadioButton ID="rbStandard" runat="server" Text="Standard" GroupName="Mode" Checked="true" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbPin" runat="server" Text="PIN Mode" GroupName="Mode" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbVoiceprint" runat="server" Text="Voiceprint" GroupName="Mode" /></td>
            </tr>
            <tr><td>&nbsp;</td><td>SMS Text: <asp:RadioButton ID="rbSmsTwoWayOtp" runat="server" Text="Two-Way OTP" GroupName="Mode" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbSmsTwoWayOtpPlusPin" runat="server" Text="Two-Way OTP + PIN" GroupName="Mode" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbSmsOneWayOtp" runat="server" Text="One-Way OTP" GroupName="Mode" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbSmsOneWayOtpPlusPin" runat="server" Text="One-Way OTP + PIN" GroupName="Mode" /></td>
            </tr>
            <tr><td>&nbsp;</td><td>Phone App: <asp:RadioButton ID="rbPhoneAppStandard" runat="server" Text="Standard" GroupName="Mode" />
                &nbsp;&nbsp;<asp:RadioButton ID="rbPhoneAppPin" runat="server" Text="PIN Mode" GroupName="Mode" /></td>
            </tr>
            <tr><td>PIN:</td><td><asp:TextBox ID="txtPin" runat="server"></asp:TextBox></td></tr>
            <tr><td>Pin Type:</td><td><asp:RadioButton ID="rbSha1" runat="server" Text="SHA1" GroupName="PinType" Checked="true"/>
                <asp:RadioButton ID="rbPlain" runat="server" Text="Plain Text" GroupName="PinType"/></td></tr>
        </table>
        <br />
        <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="Test Auth" />
        <br />
        <br />
        <table>
            <tr><td>Authenticated:</td><td><asp:Label ID="Label1" runat="server"></asp:Label></td></tr>
            <tr><td>OTP:</td><td><asp:Label ID="Label2" runat="server"></asp:Label></td></tr>
            <tr><td>Call status:</td><td><asp:Label ID="Label3" runat="server"></asp:Label></td></tr>
            <tr><td>Error id:</td><td><asp:Label ID="Label4" runat="server"></asp:Label></td></tr>
        </table>
        <br />
        <asp:Button ID="btnResetVoiceprint" runat="server" OnClick="btnResetVoiceprint_Click" Text="Reset Voiceprint" />
        <br />
        <br />
        <table>
            <tr><td>Reset Succeeded:</td><td><asp:Label ID="Label5" runat="server"></asp:Label></td></tr>
            <tr><td>Result:</td><td><asp:Label ID="Label6" runat="server"></asp:Label></td></tr>
            <tr><td>Error id:</td><td><asp:Label ID="Label7" runat="server"></asp:Label></td></tr>
        </table>
        <br />
        <asp:Button ID="btnValidateDeviceToken" runat="server" OnClick="btnValidateDeviceToken_Click" Text="Validate Device Token" />
        <br />
        <br />
        <table>
            <tr><td>Validation Succeeded:</td><td><asp:Label ID="Label8" runat="server"></asp:Label></td></tr>
            <tr><td>Result:</td><td><asp:Label ID="Label9" runat="server"></asp:Label></td></tr>
            <tr><td>Error id:</td><td><asp:Label ID="Label10" runat="server"></asp:Label></td></tr>
        </table>
    </div>
    </form>
</body>
</html>
