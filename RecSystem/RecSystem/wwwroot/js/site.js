// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var x = document.getElementsByClassName("navbar_item_link");

for (i = 0; i < x.length; i++) {
    if (x[i].innerHTML == document.title) {

        x[i].style.borderBottom = "5px solid #ECD4A0";
        x[i].style.paddingBottom = "5px";
    }
}