<%@ Page Title="" Language="C#" MasterPageFile="~/places.Master" AutoEventWireup="true" CodeBehind="editplace.aspx.cs" Inherits="final_project.editplace" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="edit_place_panel" runat="server">

            <div class="panel-default panel-primary">
                <div class="panel-heading">
                    <a href="main_content.aspx" title="View Places!!"><span class="glyphicon glyphicon-chevron-left"></span></a>
                    <h2>Edit <span id="page_title"></span></h2>
                </div>
                <div class="panel-body">
                    <div id="place_error" runat="server">
                        <div>
                            <asp:Label ID="edit_place_title_label" Text="Place title:" runat="server"></asp:Label>
                            <asp:TextBox ID="edit_place_title" class="form-control" placeholder="Enter Place title" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Please enter Any Place" ControlToValidate="edit_place_title"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:Label ID="edit_description_label" Text="Place Description:" runat="server"></asp:Label>
                            <asp:TextBox ID="edit_description" placeholder="Enter Description(optional)" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <!--
                        <asp:Label ID="created_on_label" Text="Created on : " runat="server"></asp:Label>
                    <asp:TextBox ID="created_on" disabled="true" class="form-control" runat="server"></asp:TextBox>
                    </div> -->
                          
                            <asp:Button ID="update_btn" class="update_btn" OnClick="edit_place" Text="Update" runat="server"></asp:Button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </asp:Content>
