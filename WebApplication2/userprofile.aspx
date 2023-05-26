﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication2.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/sign-up.png" width="100px" />
                                    <h3>Your Profile</h3>
                                    <span>Account status - </span>
                                    <asp:Label ID="Label1" class="badge rounded-pill text-bg-info" runat="server" Text="Your status"></asp:Label>

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter Full Name" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter Date of Birth" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Enter Contact Number" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Enter Email ID" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Select" Value="selec" />
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                        <asp:ListItem Text="Goa" Value="Goa" />
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />

                                    </asp:DropDownList>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" class="form-control" placeholder="Enter City" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Enter Pin Code" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Enter Full Address" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>

                            </div>

                        </div>


                        <div class="row">

                            <div class="col">
                                <center>
                                    <span class="badge rounded-pill text-bg-info">User Credentials</span>
                                </center>

                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" class="form-control" placeholder="Enter User ID" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" class="form-control" placeholder="Enter Password" runat="server" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" class="form-control" placeholder="Enter New Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                            </div>

                        </div>
                        <br />

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-outline-success btn-block btn-sm" ID="Button1" runat="server" Text="Update" />
                                    </div>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/download%20(1).jpg" width="100px" />
                                    <h3>Your Added Recipes</h3>
                                    <span>Account status - </span>
                                    <span class="badge text-bg-info">Your Recipes info</span>
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
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server"></asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>


    <a href="homepage.aspx"><<--Back to Home</a>
    <br />
    <br />

</asp:Content>
