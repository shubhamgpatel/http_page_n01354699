<%@ Page Title="" Language="C#" MasterPageFile="~/places.Master" AutoEventWireup="true" CodeBehind="view_place.aspx.cs" Inherits="final_project.view_place" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" panel-default display_page_panel">
                  <div class="panel panel-primary">
				<div class="panel-heading">
					<span id="place_title_heading" runat="server">Place : </span>
                  <span class="panel_date">Created on : <span id="place_created_on" runat="server"> </span></span> 
				</div>
				<div class="panel-body">
                    <div class="col-md-8 col-lg-8 col-sm-8 view_place_content">
                        <span class="place_error" runat="server"></span>
     
                        <dl class="dl-horizontal" runat="server">
                          <dt>Place Title:</dt>
                          <dd><span id="place_title" class="" runat="server"></span></dd>
                          <dt>Place Description:</dt>
                          <dd><textarea ID="place_desc" runat="server" class="place_descript"></textarea></dd>
                          
                        </dl>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-4">
                        <img src="#" id="place_image" alt="Place-image" class="img-responsive"/>
                    </div>
					
				</div>
                   <a href="main_content.aspx" title="View Places!!"><span class="glyphicon glyphicon-chevron-left"></span></a>
			</div>
     </div>
</asp:Content>
