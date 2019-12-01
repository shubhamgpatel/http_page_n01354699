<%@ Page Title="" Language="C#" MasterPageFile="~/places.Master" AutoEventWireup="true" CodeBehind="main_content.aspx.cs" Inherits="final_project.main_content" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="add_place">
        <div class="place_header">
             <h1>Pages</h1>
            <a href="add_place.aspx"><span class="glyphicon glyphicon-plus add_place_btn"></span></a>
        </div>
        <asp:label for="place_search" runat="server">Search:</asp:label>
                <asp:TextBox ID="place_search" runat="server"></asp:TextBox>
            
            <asp:Button runat="server" text="Search"/>
       <div id="place_result" runat="server"></div>
    </div>
    

  

</asp:Content>
