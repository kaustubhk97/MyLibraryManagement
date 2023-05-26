<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication2.adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/adminuser.png" width="150px" />
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Admin ID</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter Admin ID" runat="server"></asp:TextBox>

                                    <label>Member Password</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-outline-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                    
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><<--Back to Home</a>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
