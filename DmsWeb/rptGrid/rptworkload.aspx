<%@ Page Title="" Language="VB" MasterPageFile="~/Template/ReportMasterPage.master"
    AutoEventWireup="false" CodeFile="rptworkload.aspx.vb" Inherits="rptGrid_rptworkload" %>

<%@ Register Assembly="MycustomDG" Namespace="MycustomDG" TagPrefix="Saifi" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="rptStyleSheet.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%">
        <tr>
            <td align="center" class="CssHead" width='100%' >
                สรุปผลปริมาณงาน<asp:label ID="lblRepType" runat="server" Font-Bold="true" ></asp:label>ทั้งหมดต่ออัตรากำลังคนของ 
                <asp:Label ID="lblOrgName" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="CssHead">
                ระหว่าง วันที่
                <asp:Label ID="lbl_fromdt" runat="server"></asp:Label>
                &nbsp;ถึง
                <asp:Label ID="lbl_todt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  class="Csslbl" align="right" >
                <asp:Label ID="lblTimeFrame" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="celllabel">
                <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" >
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left" >
                    <tr>
                        <td class="Csslbl" align="left" >
                            หมายเหตุ :<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.	เปลี่ยนแปลงวันมาตรฐานงานอนุมัติแก้ไขสูตรการผลิต (ม.36) จาก 1 วัน เป็น 0.33 วัน และงานขอขยายเวลานำเข้าเครื่องจักร จาก 2 วัน เป็น 1.9 วัน ณ วันที่ 4 ต.ค.2544<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.	เปลี่ยนแปลงวันมาตรฐานงานขอรับการส่งเสริมฯ (60 วัน) จาก 4 วัน เป็น 1.9 วัน และงานขออนุญาตเปิดดำเนินการจาก 3 วันเป็น 1.5 วัน ณ วันที่ 6 ก.พ. 2545<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.  สูตรการคำนวณปริมาณ (Man days) = SUM(จำนวนงาน * เวลามาตรฐานในแต่ละกลุ่มเรื่อง)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4.  สูตรการคำนวณกำลังคน (Man days) = (จำนวนวันทำการ * Lost factor)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5.	สูตรการคำนวณ Work Load = <u>(ผลรวมปริมาณงานแต่ละกลุ่ม * เวลามาตรฐาน) * 100</u><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(จำนวนวันทำการ – จำนวนวันลา) * Lost Factor<br />
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td class="Csslbl" align="left" >
                            การคิด Lost Factor<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.	ชำนาญการพิเศษ	เวลาที่ใช้ในการประชุม สัมมนาและอื่นๆ 40%(ใช้ 60% ในการคำนวณ)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.	ชำนาญการ		เวลาที่ใช้ในการประชุม สัมมนาและอื่นๆ 30%(ใช้ 70% ในการคำนวณ)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.	ปฏิบัติการ   		เวลาที่ใช้ในการประชุม สัมมนาและอื่นๆ 20%(ใช้ 80% ในการคำนวณ)<br />
                            การคิดกำลังคน คิดจาก จำนวนวันทำการ * Lost factor ของแต่ละคนหักวันลา
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

