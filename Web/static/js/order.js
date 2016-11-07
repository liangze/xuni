ProductList = new Array();

var totalCollectedBV = 0.00;
			  
function Product(id, price, bv, ct, rowid) {
	this.id = id;
	this.price = price;
	this.bv = bv;
	this.ct = ct;
	this.rowid = rowid;
}
			
function addProduct(id, price, bv, ct, rowid) {
	ProductList[ProductList.length] = new Product(id,price,bv,ct,rowid);
}

function init() {
	var thisform = document.salesform;
	var qty = 0;

	for (var i=0; i < ProductList.length; i++) {
		var obj = eval("thisform.Qty_"+ProductList[i].ct+"_"+ ProductList[i].id);
		
		if (obj != null)
			qty = obj.value;

		if (qty > 0) {
			var total = eval("Amt_"+ProductList[i].ct+"_"+ ProductList[i].id);
			total.innerText = qty==0?"": decFormat(ProductList[i].price * qty);

			invokeCart(i, ProductList[i].rowid, obj);
		}

	}

	calcGrandTotal();
}

function calcUnit(idx, qty) {
	var unit = qty.value;
	
	if (unit.length > 0 && (isNaN(unit) || unit <= 0)) {
		alert("Quantity must be numeric number.");
		qty.value = "";
		qty.focus();
		return;
	}
			
	var total = eval("Amt_"+ProductList[idx].ct+"_"+ ProductList[idx].id);
		
	var bv = document.getElementById("Bv_"+ProductList[idx].ct+"_"+ ProductList[idx].id) != null ? eval("Bv_"+ProductList[idx].ct+"_"+ ProductList[idx].id) : null;

	total.innerText = unit==0?"": decFormat(ProductList[idx].price * unit);
	
	if (bv != null)
		bv.innerText = unit==0?"": decFormat(ProductList[idx].bv * unit);
	
	qty.value = unit==0?"":unit * 1;
	
	calcGrandTotal();
}
	
function calcFocUnit(idx, qty) {
	var unit = qty.value;
	
	if (isNaN(unit)) {
		alert("Quantity must be numeric number.");
		qty.value = "";
		qty.focus();
		return;
	}
}

function calcAdminFee(thisObj) {
	thisObj.value = decFormat(thisObj.value *1);
	calcGrandTotal();
}
					
function calcDelivery(thisObj) {
	thisObj.value = decFormat(thisObj.value *1);
	calcGrandTotal();
}

function decFormat(amount) {
	var i = parseFloat(amount);
	if (isNaN(i)) { i = 0.00; }
	var minus = '';
	if (i < 0) { minus = '-'; }
	i = Math.abs(i);
	i = parseInt((i + .005) * 100);
	i = i / 100;
	s = new String(i);
	if (s.indexOf('.') < 0) { s += '.00'; }
	if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
	s = minus + s;
	
	return s;
}

function calcGrandTotal() {
	var thisform = document.salesform;
	selectedUnit = 0;
	total = 0;
	bv = 0;
	qty = 0;

	for (var i=0; i < ProductList.length; i++) {
		var obj = eval("thisform.Qty_"+ProductList[i].ct+"_"+ ProductList[i].id);
		
		if (obj != null)
			qty = obj.value;

		total += ProductList[i].price * qty;
		bv += ProductList[i].bv * qty;
		selectedUnit +=  qty;
	}


	if (document.getElementById("TotalBv") != null)
		TotalBV.innerText = bv==0?"0":bv;

	if (document.getElementById("Total") != null)
		Total.innerText = total==0?"0.00":decFormat(total);

//	if (total == 0){
//		disableSubmitBtn(true);
//	} else {
//		disableSubmitBtn(false);
//	}
	
	if (document.getElementById("Adjustmentratio") != null)
		total = total * (Adjustmentratio.innerText/100);

	if (thisform.AdminFee != null)
		total += (thisform.AdminFee.value * 1);

	if (thisform.DeliveryFee != null)
		total += (thisform.DeliveryFee.value * 1);

	if (document.getElementById("Grandtotal") != null)
		Grandtotal.innerText = total==0?"0.00":decFormat(total);
	

	totalCollectedBV = bv;

	//refreshBalance();
}
			
function disableSubmitBtn(truefalse) {
	var thisform = document.salesform;
	thisform.btnSubmit.disabled = truefalse;
}

/*		 
function refreshBalance() {
	//var thisform = document.salesform;
	paid = amountPaid.innerText *1;
	balance.innerText = paid==0?"0.00":decFormat(Grandtotal.innerText - paid);
}
*/
			
function calcAmountPaid(_this) {
	var thisform = _this.form;
	paid = 0;
	
	if (Grandtotal.innerText.length == 0 || Grandtotal.innerText <= 0){
		alert('Grand total cannot be EMPTY and value must greater than ZERO.');
		_this.value = '';
		return false;
	} else if (isNaN(_this.value)) {
		alert("Amount must be in numeric number.");
		_this.value = "";
		_this.focus();
		return false;
	} else {

		for (var i=0; i <thisform.PayAmt.length; i++) {
			paid += (thisform.PayAmt[i].value *1);
		}

		if (document.getElementById("amountPaid") != null)
			amountPaid.innerText = paid==0?"0.00":decFormat(paid);

		if (document.getElementById("balance") != null)
			balance.innerText = paid==0?"0.00":decFormat(Grandtotal.innerText - paid);
	}
}


var cartTable = "Cart"; 		// default cart object
var emptyMessage = "No Purchase Item";	// default message
var noOfItemInCart = 0;

function addToCart(tidx, data) {

	// switch off empty message
	offMessage();

	var table = document.getElementById(cartTable);
	var header = table.rows[0];
	var rowSize = table.rows.length;
	var colSize = header.cells.length;


	var thisRow = table.insertRow();

	thisRow.setAttribute("id","t"+ tidx);
	thisRow.className = rowSize%2==0 ?"even" : "odd";

	for (var i=0; i < colSize; i++) {
		cell = thisRow.insertCell(i);

		if (i == 0)
			cell.innerHTML = rowSize +".";

		else {
			cell.innerHTML = data[i-1];
			
		}

		cell.align = header.cells[i].align;
	}

	noOfItemInCart += 1;

}

function deleteFromCart(tidx) {

	var rowidx = getCart(tidx);
	var table = document.getElementById(cartTable);
	var thisRow = table.rows[rowidx];
	

	if (thisRow != null) {
		table.deleteRow(rowidx);

		noOfItemInCart -= 1;
	}

	refreshCart();
}

function updateCart(rowidx, data) {

	var table = document.getElementById(cartTable);
	var thisRow = table.rows[rowidx];


	if (thisRow != null) {
		var colSize = thisRow.cells.length;
		for (var i=1; i < colSize; i++) {
			
			cell = thisRow.cells[i];
			cell.innerHTML = data[i-1];
		}
	}
}

function offMessage() {

	// turn off empty product message
	if (noOfItemInCart == 0) {
		var table = document.getElementById(cartTable);
		var thisRow = table.rows[1];

		if (thisRow != null) {
			table.deleteRow(1);
		}
	}
}

function onMessage() {

	// turn on empty product message

	if (noOfItemInCart == 0) {
		var table = document.getElementById(cartTable);
		var rowSize = table.rows.length;

		if (rowSize == 1) {
			var thisRow = table.insertRow();
			var cell = thisRow.insertCell(0);
			
			cell.innerHTML = emptyMessage;
			cell.align = "center";
			cell.colSpan = "10";
		}
	}
}

function refreshCart() {

	var table = document.getElementById(cartTable);
	var rowSize = table.rows.length;

	for (var i=1; noOfItemInCart > 0 && i < rowSize; i++) {
		var thisRow = table.rows[i];
		var cell = thisRow.cells[0];

		thisRow.className = i%2==0 ?"even" : "odd";

		cell.innerHTML = i +".";
	}
	
	onMessage();
}

function getCart(tidx) {

	// search selected product in cart

	var table = document.getElementById(cartTable);
	var rowSize = table.rows.length;
	
	var rowidx = -1;
	var tmptidx = "t"+ tidx;
	

	for (var i=0; i < rowSize; i++) {
		
		var thisRow = table.rows[i];
		var thisId = thisRow.getAttribute("id");
		
		if (thisId == tmptidx) {
			
			rowidx = i;
			break;
		}
	}

	return rowidx;
}

function notifyCart(tidx, data) {

	var rowidx = getCart(tidx);

	if (rowidx < 0) {
	
		addToCart(tidx, data);

	} else {
		updateCart(rowidx, data);

	}

}

function invokeCart(idx, tidx, qtyObj) {

	calcUnit(idx,qtyObj);
}