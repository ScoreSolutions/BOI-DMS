<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucHeader_Page.ascx.vb" Inherits="Template_ucHeader_Page" %>
<script src="../Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
<link href="../css/screen.css" media="screen" rel="stylesheet" type="text/css" />

<body topmargin="15">
<div id="header">
	<div>
	  <script language="javascript">
	if (AC_FL_RunContent == 0) {
		alert("This page requires AC_RunActiveContent.js.");
	} else {
		AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0','name','flash_header','width','1022','height','111','align','middle','id','flash_header','src','../flash/flash_header','quality','high','wmode','transparent','bgcolor','#ffffff','allowscriptaccess','sameDomain','allowfullscreen','false','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','../flash/flash_header' ); //end AC code
	}
      </script>
      <noscript>
      <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" name="flash_header" width="1022" height="111" align="middle" id="flash_header">
        <param name="allowScriptAccess" value="sameDomain" />
        <param name="allowFullScreen" value="false" />
        <param name="movie" value="../flash/flash_header.swf" />
        <param name="quality" value="high" />
        <param name="wmode" value="transparent" />
        <param name="bgcolor" value="#ffffff" />
        <embed src="../flash/flash_header.swf" quality="high" wmode="transparent" bgcolor="#ffffff" width="1022" height="111" name="flash_header" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />      
</object>
      </noscript>
  <ul class="menu1">		 
			<li><a href="http://www.boi.go.th/index.php?page=contactus" target="_blank" class="fontontop">ติดต่อบีโอไอ</a></li>		
	  <li class="dot"></li>	
			<li runat="server" id="linkHelp1"><a href="mannual/user.pdf" target="_blank" class="fontontop">ช่วยเหลือ</a></li>
			
			<%--<li class="dot"></li>
			<li><a href="logout.aspx">Logout</a></li>--%>
		</ul>
		
	</div>
</div>
</body>