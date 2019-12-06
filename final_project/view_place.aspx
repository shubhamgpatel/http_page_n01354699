<%@ Page Title="" Language="C#" MasterPageFile="~/places.Master" AutoEventWireup="true" CodeBehind="view_place.aspx.cs" Inherits="final_project.view_place" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class=" panel-default display_page_panel">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <a href="main_content.aspx" title="View Places!!"><span class="glyphicon glyphicon-chevron-left"></span></a>
                    <h1>Place :<span id="place_title_heading" runat="server"></span></h1>

                    <span class="panel_date">Created on : <span id="place_created_on" runat="server"> </span></span>

                </div>
                <div class="panel-body">
                    <div class="col-md-12 col-lg-12 col-sm-12 view_place_content">


                        <dl class="dl-horizontal" runat="server">
                            <dt>Place Title:</dt>
                            <dd><span id="place_title" runat="server"></span>
                            </dd>

                            <dt>Place Description:</dt>
                            <dd><span ID="place_desc" runat="server" class="place_descript"></span>
                            </dd>


                        </dl>
                        <!-- christine lab for reference --->
                        <ASP:Button OnClientClick="if(!confirm('Are you sure you want to delete this Place?')) return false;" OnClick="DeletePlace_aspx" class="delete_btn_view " Text="Delete this place" runat="server" />
                        <!-- onclick will call  the deleteplace function which is in codebehind i.e cs file -->

                        <span class="place_error" runat="server"></span>
                    </div>


                </div>

            </div>
        </div>
    </asp:Content>
