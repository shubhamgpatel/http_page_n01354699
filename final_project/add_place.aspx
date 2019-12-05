﻿<%@ Page Title="" Language="C#" MasterPageFile="~/places.Master" AutoEventWireup="true" CodeBehind="add_place.aspx.cs" Inherits="final_project.add_place" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel-default panel-primary">
            <div class="panel-heading"> <a href="main_content.aspx" title="View Places!!"><span class="glyphicon glyphicon-chevron-left"></span></a> 
                <h2 class="add_new_heading">Add New Place</h2>
            </div>
            <div class="panel-body">
                <div>
                    <asp:TextBox ID="create_place_title" class="form-control" placeholder="Enter Place Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" EnableClientScript="true" ErrorMessage="Please enter Any Place" ControlToValidate="create_place_title"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="create_description" placeholder="Enter Description(optional)" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div>

                </div>
                <asp:Button OnClick="Add_Place" Text="Add Place" CssClass="create_btn" runat="server" />
            </div>
        </div>

    </asp:Content>
