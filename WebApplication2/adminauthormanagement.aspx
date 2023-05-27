<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="WebApplication2.adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher Details</h3>

                                    <img src="images/writer.png" width="100px" />

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Chef ID" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-outline-success" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter Author Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>







                        <br />

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-outline-success btn-block btn-lg" runat="server" Text="Add" OnClick="Button2_Click" />


                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-outline-info btn-block btn-lg" runat="server" Text="Update" OnClick="Button3_Click" />


                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-outline-danger btn-block btn-lg" runat="server" Text="Delete" OnClick="Button4_Click" />


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
                                    <h3>Publisher List</h3>

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>

                            <div class="col">
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="Author ID" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>

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
