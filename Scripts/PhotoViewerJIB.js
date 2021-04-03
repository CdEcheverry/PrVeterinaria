var canvas = document.getElementById('canvas');
var image = document.getElementById('imagenOriginal');
var element = canvas.getContext("2d");
var angleInDegrees = 0;
var zoomDelta = 0.1;
var currentScale = 0.33;
var currentAngle = 0;
var canvasWidth = 300;
var startX, startY, isDown = false;


function clear() {
    element.clearRect(-image.width / 2 - 2, -image.width / 2 - 2, image.width + 4, image.height + 4);
}

var cargar = function () {
    //canvas = document.getElementById('canvas');
    /*image = document.getElementById('imagenOriginal');
    element = canvas.getContext("2d");*/

    element.translate(canvas.width / 2, canvas.height / 2);

    element.restore();

    drawImage();
    jQuery('#canvas').attr('data-girar', 0);
    this.disabled = true;
};

jQuery('#giraresq').click(function () {
    angleInDegrees = 45;
    currentAngle += angleInDegrees;
    drawImage();
});

jQuery('#girardir').click(function () {
    angleInDegrees = -45;
    currentAngle += angleInDegrees;
    drawImage();
});

jQuery('#zoomIn').click(function () {
    currentScale += zoomDelta;
    drawImage();
});
jQuery('#zoomOut').click(function () {
    currentScale -= zoomDelta;
    drawImage();
});

canvas.onmousedown = function (e) {
    var pos = getMousePos(canvas, e);
    startX = pos.x;
    startY = pos.y;
    isDown = true;
}

canvas.onmousemove = function (e) {
    if (isDown === true) {
        var pos = getMousePos(canvas, e);
        var x = pos.x;
        var y = pos.y;

        element.translate(x - startX, y - startY);
        drawImage();

        startX = x;
        startY = y;
    }
}
canvas.onmouseup = function (e) {
    isDown = false;
}

function drawImage() {
    clear();
    element.save();
    element.scale(currentScale, currentScale);
    element.rotate(currentAngle * Math.PI / 180);
    element.drawImage(image, -image.width / 2, -image.width / 2);
    element.restore();
}

function getMousePos(canvas, evt) {
    var rect = canvas.getBoundingClientRect();
    return {
        x: evt.clientX - rect.left,
        y: evt.clientY - rect.top
    };
}

function cerrar() {

    // Store the current transformation matrix context.save(); 
    // Use the identity matrix while clearing the canvas 
    clear();
    element.setTransform(1, 0, 0, 1, 0, 0);
    element.rotate(0 * Math.PI / 180);
    // Restore the transform context.restre();
    /*
    element.translate(0, 0);
    element.save();
    element.drawImage(image, 0, 0);
    element.restore();*/
}