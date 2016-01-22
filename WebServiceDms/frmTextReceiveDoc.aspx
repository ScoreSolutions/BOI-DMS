<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmTextReceiveDoc.aspx.vb" Inherits="WebServiceDms.frmTextReceiveDoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function ShowDialog() {
                MyObject = new ActiveXObject("WScript.Shell");
                MyObject.Run("file:///C:/Windows/notepad.exe");
            }

            function RunExe() {
                try {
                    var path = encodeURI("file:///C:/Program Files (x86)/Quest Software/Toad for Oracle/TOAD.exe");
                    alert(path);
                    var ua = navigator.userAgent.toLowerCase();
                    if (ua.indexOf("msie") != -1) {
                        MyObject = new ActiveXObject("WScript.Shell")
                        MyObject.Run(path);
                    } else {
                        var file = Components.classes["@mozilla.org/file/local;1"].createInstance(Components.interfaces.nsILocalFile);
                        file.initWithPath(path);
                        file.launch();
                    }
                } catch (ex) {
                    alert(ex.toString());
                }
            } 

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="RunExe();return false;" />
    </div>
    </form>
</body>
</html>
