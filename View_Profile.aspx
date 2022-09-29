<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Profile.aspx.cs" Inherits="SwimmingPoolAndGymManagement.View_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile_page</title>
</head>
<body style ="background-color : aqua ">
     <form id="form1" runat="server">
        <div style =" background-color : cadetblue  ;display : flex  ">
            <h1>
                <asp:Label ID="Label2" runat="server" Text="Welcome" style =" margin-left :790px"></asp:Label>

            </h1>

                <asp:Button ID="Button1" runat="server" Text="Home" Style="-moz-border-radius: 10px; -webkit-border-radius: 10px; -khtml-border-radius: 10px; cursor: pointer; padding: 5px;margin-left: 450px; " OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Logout" Style="-moz-border-radius: 10px; -webkit-border-radius: 10px; -khtml-border-radius: 10px; cursor: pointer; padding: 5px;" OnClick="Button2_Click" />
        </div>

  

         <div style="height : 725px ; background-color : darksalmon ;text-align :center  ">
             <br />
             <br />
             <div style="height : 600px ; width : 500px ;background-color:lightgreen ;margin-left : 600px ;border-radius :25px ;margin-top : 20px">
                 

                 <div style ="background-color : deepskyblue ;height : 50px;border-radius : 25px;text-align : center ;">
                     <h1>
                         <asp:Label ID="Label1" runat="server" Text="Personal Info" style="text-align : center "></asp:Label>
                     </h1>
                     
                 </div>

                 <br />

                 <div >
                     <asp:Label ID="Label3" runat="server" Text="Username : "></asp:Label>
                     <asp:TextBox ID="TextBox1" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div style ="margin-right: 7px;">
                     <asp:Label ID="Label4" runat="server" Text="FirstName : "></asp:Label>
                     <asp:TextBox ID="TextBox2" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div style ="margin-right: 7px;">
                     <asp:Label ID="Label5" runat="server" Text="LastName : "></asp:Label>
                     <asp:TextBox ID="TextBox3" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div style ="margin-left: 17px;">
                     <asp:Label ID="Label6" runat="server" Text="Email : "></asp:Label>
                     <asp:TextBox ID="TextBox4" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br /> 

                 <div style ="margin-left: 6px;">
                     <asp:Label ID="Label7" runat="server" Text="Gender : "></asp:Label>
                     <asp:TextBox ID="TextBox5" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div style ="margin-right: 40px;">
                     <asp:Label ID="Label8" runat="server" Text="Phone Number : "></asp:Label>
                     <asp:TextBox ID="TextBox6" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div style ="margin-left: 19px;>
                     <asp:Label ID="Label9" runat="server" Text="Status : "></asp:Label>
                     <asp:TextBox ID="TextBox7" runat="server" ReadOnly ="true" ></asp:TextBox>
                 </div>

                 <br />

                 <div>
                     <asp:CheckBox ID="CheckBox1" runat="server" Visible="false" OnCheckedChanged="CheckBox1_CheckedChanged" />
                     <asp:Label ID="Label10" runat="server" Text="Make me admin---->" Visible ="false" ></asp:Label>
                     <asp:Button ID="Button3" runat="server" Text="Submit Request"  visible="false"  OnClick="Button3_Click"/>
                 </div>

                 <br />

                 <div>
                     <asp:Label ID="Label11" runat="server" Text="Successfully submitted for Approval"  visible ="false" ></asp:Label>
                 </div>
                 <div>
                     <asp:Label ID="Label12" runat="server" Text="Select the check box for Submission!!"  visible ="false" ></asp:Label>
                 </div>

                 <br />

                <div>

                    <asp:Button ID="Button4" runat="server" Text="Edit" OnClick="Button4_Click" />
                    
                    <asp:Button ID="Button5" runat="server" Text="Update" OnClick="Button5_Click" visible ="false" />

                    <asp:Button ID="Button6" runat="server" Text="Cancel" OnClick="Button6_Click" visible ="false" />
                </div>
             </div>
             

         </div>
        
    </form>
</body>
</html>
