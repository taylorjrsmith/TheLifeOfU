<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheTaleOfU.ScenarioBuilder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!--Center div-->

        <div class="senario-name-container input-field">
            <input id="senario_name" type="text" placeholder="enter senario name" />
            <label for="sernario_name">Scenario Name</label>
        </div>

        <div class="textarea">
            <textarea placeholder="Enter your senario here!" rows="20" id="senario_text" cols="40" class="ui-autocomplete-input" autocomplete="off" role="textbox" aria-autocomplete="list" aria-haspopup="true"></textarea>
        </div>

        <div class="configuration">
            <i class="fas fa-cog fa-2x tooltipped" data-position="down" data-tooltip="configure senario"></i>
        </div>

        <div class="created-senario-container">
            <h6>Created Senarios</h6>

            <div class="list-items">
                <ul class="created-senario-list">
                    <li class="item">
                        <h5>Test</h5>
                    </li>
                    <li class="item">
                        <h5>Test</h5>
                    </li>
                    <li class="item">
                        <h5>Test</h5>
                    </li>

                </ul>
            </div>
        </div>

        <div class="add-option-button">
            <a class="btn-floating btn-large waves-effect waves-light red tooltipped" data-position="right" data-tooltip="add option"><i class="fas fa-plus"></i></a>
        </div>

        <div class="option-container">
            <input id="option_name" type="text" placeholder="enter option name" />

            <div class="linked-senario">
                <div class="input-field col s12">
                    <select class="linked-senario">
                        <option value="1">Option 1</option>
                        <option value="2">Option 2</option>
                        <option value="3">Option 3</option>
                    </select>
                    <label>Choose Linked Senario</label>
                </div>
            </div>

            <div class="close">
                <a class="waves-effect waves-light btn">Close</a>
            </div>

        </div>

        <div class="add-to-tree">
            <a class="waves-effect waves-light btn">Add to senario tree</a>
        </div>
    </div>

</asp:Content>
