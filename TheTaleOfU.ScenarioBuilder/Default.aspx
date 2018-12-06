<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheTaleOfU.ScenarioBuilder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" >
        <div class="button-container">
            <a class="btn-floating btn-large waves-effect waves-light red"><i class="fas fa-plus"></i></a>
        </div>

        <div class="senario-container">
            <h6>Created Senarios</h6>

            <div class="list-itmes">
                <ul class="list-item-nav" id="Add-item">
                    <li class="item">
                        <h5>Test Li</h5>
                    </li>
                    <li class="item">
                        <h5>Test Li</h5>
                    </li>
                    <li class="item">
                        <h5>Test Li</h5>
                    </li>
                </ul>
            </div>
        </div>

        <div class="flex">
            <input class="input" type="text" id="name" placeholder="Senario Name">
        </div>

        <div class="container flex">
            <textarea placeholder="Enter your senario here!" rows="20" id="senario_text" cols="40" class="ui-autocomplete-input" autocomplete="off" role="textbox" aria-autocomplete="list" aria-haspopup="true"></textarea>
        </div>

        <div class="container flex">
            <a class="button waves-effect waves-light btn"><i class="material-icons left" onclick="AddElement()"></i>button</a>
        </div>

    </div>
    <script src="main.js"></script>
</asp:Content>
