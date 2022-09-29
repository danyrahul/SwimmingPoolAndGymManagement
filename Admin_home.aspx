<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_home.aspx.cs" Inherits="SwimmingPoolAndGymManagement.Admin_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin_Home</title>
    <style>
        #main
        {
            width: 100%;
            height: 100%;
            background-color : aqua ;
            display: flex;          
        }

        #main div 
        {
                  
  
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style =" background-color : cadetblue  ;display : flex  ">
            <h1>
                <asp:Label ID="Label2" runat="server" Text="Welcome" style =" margin-left :790px"></asp:Label>

            </h1>

                <asp:Button ID="Button1" runat="server" Text="My Profile" Style="-moz-border-radius: 10px; -webkit-border-radius: 10px; -khtml-border-radius: 10px; cursor: pointer; padding: 5px;margin-left: 550px; " OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Logout" Style="-moz-border-radius: 10px; -webkit-border-radius: 10px; -khtml-border-radius: 10px; cursor: pointer; padding: 5px;" OnClick="Button2_Click" />
        </div>


        <div id ="main">

            <div style="background-color:coral;height:445px;width : 30% ;border-radius : 15px ">

                <br />
                <br />
                <br />

                <div style ="text-align : center ;font-size : x-large ;cursor: pointer  ">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Clients</asp:LinkButton>
                </div>

                <br />
                <br />

                <div style="text-align : center ;font-size : x-large ;cursor: pointer">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Admins</asp:LinkButton>
                </div>

                
                <br />
                <br />

                <div style="text-align : center ;font-size : x-large ;cursor: pointer">
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click1">Admin Approvals</asp:LinkButton>
                </div>


                
                

            </div>

            <div style="background-color:lightblue;height:645px;width : 70% ">
                
              
                <%--<% ------------- Clients Table Init ----------------- %>--%>

                <asp:GridView ID="clientsData" CssClass="table" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="clientsData_RowCommand" OnRowCancelingEdit="clientsData_RowEditCancelCommand"
                    OnRowUpdating="clientsData_RowUpdateCommand" OnRowDeleting="clientsData_RowDeleteCommand"
                    OnRowEditing="clientsData_RowEditCommand" OnRowDataBound="clientsData_OnRowDataBound"
                    ShowFooter="true" ShowHeaderWhenEmpty="true">

                    <Columns>

                        <asp:TemplateField HeaderText="UserName" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text ='<%# Eval("UserName") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" Text ='<%# Eval("UserName") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender" ItemStyle-Width="120px" ItemStyle-CssClass="Country">
                            <ItemTemplate>
                                <asp:Label  ID="Label2" Text ='<%# Eval("Gender") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" Text ='<%# Eval("Gender") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FirstName" ItemStyle-Width="120px" ItemStyle-CssClass="Country">
                            <ItemTemplate>
                                <asp:Label  ID="Label3"  Text ='<%# Eval("FirstName") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" Text ='<%# Eval("FirstName") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="lastName" ItemStyle-Width="120px" ItemStyle-CssClass="Country">
                            <ItemTemplate>
                                <asp:Label  ID="Label4"  Text ='<%# Eval("lastName") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" Text ='<%# Eval("lastName") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </FooterTemplate>

                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="EmailId" ItemStyle-Width="120px" ItemStyle-CssClass="Country">
                            <ItemTemplate>
                                <asp:Label  ID="Label5" Text ='<%# Eval("EmailId") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" Text ='<%# Eval("EmailId") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            </FooterTemplate>
   
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PhoneNumber" ItemStyle-Width="120px" ItemStyle-CssClass="Country">
                            <ItemTemplate>
                                <asp:Label  ID="Label6" Text ='<%# Eval("PhoneNumber") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" Text ='<%# Eval("PhoneNumber") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate >
                                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                            </FooterTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField  >
                            <ItemTemplate >
                                <asp:Button ID="Button3" runat="server" Text="Delete"   CommandName="Delete" ToolTip="Delete" width="50px" height="25px" />
                                <asp:Button ID="Button4" runat="server" Text="Edit"  CommandName="Edit" ToolTip="Edit" width="50px" height="25px" />
                                <asp:Button ID="Button8" runat="server" Text="Approve"  CommandName="Update" ToolTip="Approve" width="100px" height="25px" />
                            </ItemTemplate>
                            <EditItemTemplate >
                                <asp:Button ID="Button5" runat="server" Text="Save"  CommandName="Update" ToolTip="Save" width="50px" height="25px" />
                                <asp:Button ID="Button6" runat="server" Text="Cancel"  CommandName="Cancel" ToolTip="Cancel" width="50px" height="25px" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button7" runat="server" Text="AddNew"  CommandName="AddNew" ToolTip="AddNew" width="80px" height="25px" />
                            </FooterTemplate>
                        </asp:TemplateField>

                    </Columns>                    
                </asp:GridView>
            </div>           
        </div>
    </form>
</body>
</html>
