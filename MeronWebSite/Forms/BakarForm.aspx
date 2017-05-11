<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BakarForm.aspx.cs" Inherits="Forms_BakarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {

         

            $('.Parking').change(function () {
                $('.carForm').show();
            });

        });


    </script>
    <div class="BakarForm">
        <div><h4>טופס בקרי שטח</h4></div>
        <div>

            <div>אנא בחר אחת מהאפשרויות הבאות:</div>
            <div>
                <input type="radio" id="Parking1"  name="Parking"  class="Parking"/>חניון
             <div>
                   <input type="radio" id="Parking2" name="Parking" class="Parking"/>תחנת מוצא
            </div>
            <div style="display:none;" class="carForm">
                <div><b>אנא מלא את פרטי הרכב</b></div>
                <div>
                    מספר רישוי: 
                <input type="text" id="carNumber" />    
                
                </div>
            </div>

                <input type="button" title="שלח" id="sndBtn" value="שלח" />

        </div>
            </div>
    </div>
</asp:Content>

