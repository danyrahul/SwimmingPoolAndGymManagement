<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_home.aspx.cs" Inherits="SwimmingPoolAndGymManagement.Customer_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer_Home</title>
    <style>

        #main
        {
            width: 100%;
            height: 100%;
            background-color : aqua ;
            display: flex;          
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style =" background-color : cadetblue ;display : flex  ">
            <h1>
                <asp:Label ID="LabelMain" runat="server" Text="Welcome" style =" margin-left :790px"></asp:Label>

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
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Slot Boking</asp:LinkButton>
                </div>

                <br />
                <br />

                <div style="text-align : center ;font-size : x-large ;cursor: pointer">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Previous Slots</asp:LinkButton>
                </div>

                
                <br />
                <br />

                <div style="text-align : center ;font-size : x-large ;cursor: pointer">
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click1">Current day Slots</asp:LinkButton>
                </div>
                
           </div>

            <div style="background-color:lightblue;height:645px;width : 70% ;border-radius : 15px">

                <br />
                

                <br />
                <br />

                <asp:GridView ID="clientsData" CssClass="table" runat="server" AutoGenerateColumns="false"
                    ShowFooter="true" ShowHeaderWhenEmpty="true"
                    OnRowDataBound="clientsData_OnRowDataBound"
                    OnRowUpdating="clientsData_RowUpdateCommand" >

                    
                    <Columns>

                        <asp:TemplateField HeaderText="SlotId" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text ='<%# Eval("SlotId") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" Text ='<%# Eval("SlotId") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>  
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Day" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" Text ='<%# Eval("Day") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" Text ='<%# Eval("Day") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>  
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Slot Timings" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate >
                                <asp:Label ID="Label3" Text ='<%# Eval("Time") %>' runat="server" />                                
                            </ItemTemplate>
                            <EditItemTemplate >
                                <asp:Label ID="TextBox3" Text ='<%# Eval("Time") %>' runat="server" />                                
                            </EditItemTemplate>
                            
                        </asp:TemplateField>

                        
                        <asp:TemplateField HeaderText="Total" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label4" Text ='<%# Eval("Total") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" Text ='<%# Eval("Total") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Available" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label5" Text ='<%# Eval("Available") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" Text ='<%# Eval("Available") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="StartDate" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label6" Text ='<%# Eval("StartDate") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" Text ='<%# Eval("StartDate") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>  
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EndDate" ItemStyle-Width="120px" ItemStyle-CssClass="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label7" Text ='<%# Eval("EndDate") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" Text ='<%# Eval("EndDate") %>' runat="server"></asp:TextBox>
                            </EditItemTemplate>  
                        </asp:TemplateField>

                        <asp:TemplateField  >
                            <ItemTemplate >
                                <asp:Button ID="Button3" runat="server" Text="Book"   CommandName="Update" ToolTip="Update" width="50px" height="25px" />
                            </ItemTemplate>
                            
                            
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>


            </div>
        
    </form>

</body>
</html>


