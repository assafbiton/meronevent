<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
  
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
     <meta name="viewport" content="initial-scale=1.0">
  <script type="text/javascript">
      var GOOGLEkEY = "AIzaSyDzBPyvq6CdVRlKl7PKXwWS9lf_tBcoHsI";
      google.charts.load('current', { 'packages': ['bar'] });
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {
          var data = google.visualization.arrayToDataTable([
            ['', '5 דקות', '15 דקות', '30 דקות'],
            ['גוש מרכז', 1000, 400, 200],
            ['גוש ירושלים', 1170, 460, 250],
            ['גוש דרום', 660, 1120, 300],
            ['גוש צפון', 660, 1120, 300]
       
          ]);

          var options = {
              bars: 'horizontal',
              hAxis: { format: 'decimal' },
              height: 300,
              colors: ['#1b9e77', '#d95f02', '#7570b3']
          };

          var chart = new google.charts.Bar(document.getElementById('barchart_material'));
          chart.draw(data, google.charts.Bar.convertOptions(options));

          setInterval(function () {
              data.setValue(0, 1, 250 + Math.round(60 * Math.random()));
              data.setValue(0, 2, 150 + Math.round(60 * Math.random()));
              data.setValue(0, 3, 140 + Math.round(60 * Math.random()));

              data.setValue(1, 1, 300 + Math.round(60 * Math.random()));
              data.setValue(1, 2, 300 + Math.round(60 * Math.random()));
              data.setValue(1, 3, 300 + Math.round(60 * Math.random()));

              data.setValue(2, 1, 300 + Math.round(60 * Math.random()));
              data.setValue(2, 2, 300 + Math.round(60 * Math.random()));
              data.setValue(2, 3, 300 + Math.round(60 * Math.random()));

              data.setValue(3, 1, 300 + Math.round(25 * Math.random()));
              data.setValue(3, 2, 300 + Math.round(25 * Math.random()));
              data.setValue(3, 3, 300 + Math.round(25 * Math.random()));

              chart.draw(data, google.charts.Bar.convertOptions(options));
          }, 5000);


          google.charts.load('current', { 'packages': ['gauge'] });
          google.charts.setOnLoadCallback(drawChart2);
      }

    

      function drawChart2() {

          var data2= google.visualization.arrayToDataTable([
            ['Label', 'Value'],
            ['חניון מגידו', 80],
            ['חניון פרוד', 55],
            ['חניון צבעון', 150],
            ['חניון עין הוזים', 68]
          ]);

          var options2 = {
              chart:{title:'כמות אוטובוסים בחניונים'},
              width: 400, height: 120,
              redFrom: 80, redTo: 150,
              yellowFrom: 75, yellowTo: 90,
              minorTicks: 5
          };

          var options3 = {
              chart: { title: 'כמות אוטובוסים בחניונים' },
              width: 400, height: 120,
              redFrom: 50, redTo: 140,
              yellowFrom: 75, yellowTo: 90,
              minorTicks: 5
          };

          var options4 = {
              chart: { title: 'כמות אוטובוסים בחניונים' },
              width: 400, height: 120,
              redFrom: 80, redTo: 190,
              yellowFrom: 75, yellowTo: 90,
              minorTicks: 5
          };

          var chart2 = new google.visualization.Gauge(document.getElementById('chart_div'));

          chart2.draw(data2, options2);

          setInterval(function () {
              data2.setValue(0, 1, 40 + Math.round(60 * Math.random()));
              chart2.draw(data2, options2);
          }, 26000);
          setInterval(function () {
              data2.setValue(1, 1, 40 + Math.round(60 * Math.random()));
              chart2.draw(data2, options3);
          }, 26000);
          setInterval(function () {
              data2.setValue(2, 1, 60 + Math.round(20 * Math.random()));
              chart2.draw(data2, options4);
          }, 26000);
      }

  </script>    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <div style=" float:right;">
        <div class="" style="direction:ltr;border:1px solid  #808080;border-radius: 5px;padding:3px;">
            <div style="direction:rtl; font-size:16px;">סה"כ אוטובוסים מתחנות המוצא</div>
            <div id="barchart_material" style="width: 500px; height: 300px; margin-top:10px;"></div>
          
        </div>
        <div style="margin-top:10px;direction:ltr;border:1px solid  #808080;border-radius: 5px;padding:3px;">
               <div style="direction:rtl;font-size:16px;">כמות אוטובוסים בחניונים</div>
              <div id="chart_div" style="width: 500px; height: 130px;"></div>
        </div>

    </div>
    <div style="float:left;border:1px solid  #808080;border-radius: 5px;padding:3px;">
<iframe width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/view?zoom=8&center=31.0461%2C34.8516&key=AIzaSyC8wakd8aHuXHuG_EwkgkI2lOKEOS3YTRc" allowfullscreen></iframe>
    </div>
    </div>
    <div style="clear:both;">
        <div style="   border:1px solid  #808080;border-radius: 5px; float:right; padding:5px; margin-left:10px;margin-top:10px;">
            <div style="direction:rtl; font-size:16px;"><b>שאטלים</b></div>
            <div>
                <table style="width:150px;">
                    <tr><td>יצאו מחניון פרוד</td><td>20</td></tr>
                    <tr><td>יצאו מחניון עין הוזים</td><td>15</td></tr>
                    <tr><td><b>סה"כ נסיעות שבוצעו</b></td><td><b>20</b></td></tr>
                </table>
            </div>
        </div>
        <div style="   border:1px solid  #808080;border-radius: 5px; float:right; padding:5px; margin-left:10px;margin-top:10px;">
            <div style="direction:rtl; font-size:16px;">מספר האוטובוסים שיגיעו להר עוד 30 דקות</div>
            <div style="font-size:30px;" id="numofbus30">20</div>
        </div>

    </div>
</asp:Content>

