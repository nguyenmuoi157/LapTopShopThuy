function onEditItem(productid, unit_price, Quantity) {
    var quantity = Number($("#Quantity_" + productid).val());
    var total = $("#totalProduct_" + productid)[0];
    var totals = $("#totals");
    var tong = Number(totals[0].innerHTML);

    unit_price = Number(unit_price);
    Quantity = Number(Quantity);
    $.ajax({
        url: '/Cart/EditCart',
        type: 'POST',
        data: {
            productId: productid,
            soluong: quantity
        },
        dataType: 'json',
        success: function (response) {
            if (response.status) {
                total.innerText = quantity * unit_price;
                //totals.innerText = totals.innerText - (Quantity * unit_price) + (quantity * unit_price);
                //totals.innerText = tong
                totals[0].innerText = tong - (Quantity * unit_price) + (quantity * unit_price);
            }
        }
    });
}



