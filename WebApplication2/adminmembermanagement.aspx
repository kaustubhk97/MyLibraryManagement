<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="WebApplication2.adminmembermanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Details </h3>
                                    <img src="images/generaluser.png" width="100px" />

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="LinkButton4" runat="server"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter Full Name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox7" CssClass="form-control mr-1" placeholder="Account Status" ReadOnly="true" runat="server"></asp:TextBox>

                                        <asp:LinkButton CssClass="btn btn-success mr-1" ID="LinkButton1" runat="server"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning  mr-1" ID="LinkButton2" runat="server"><i class="fa-solid fa-spinner"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger  mr-1" ID="LinkButton3" runat="server"><i class="fa-solid fa-trash-can"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="DOB" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Enter Contact Number" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Enter Email ID" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>


                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="State" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="City" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>PinCode</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="PinCode" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>

                            </div>


                        </div>

                        <div class="row">


                            <div class="col-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" ReadOnly="true" placeholder="Full Address" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button2" CssClass="btn btn-outline-danger btn-block btn-lg" runat="server" Text="Delete User " />


                            </div>
                        </div>


                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Members List</h3>

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
