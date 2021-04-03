/*!
 * Viewer v0.6.0
 * https://github.com/fengyuanchen/viewer
 *
 * Copyright (c) 2014-2017 Fengyuan Chen
 * Released under the MIT license
 *
 * Date: 2017-10-07T09:53:36.889Z
 */
'use strict';

function _interopDefault(ex) { return (ex && (typeof ex === 'object') && 'default' in ex) ? ex['default'] : ex; }

var $ = _interopDefault(require('jquery'));

var DEFAULTS = {
    // Enable inline mode
    inline: false,

    // Show the button on the top-right of the viewer
    button: true,

    // Show the navbar
    navbar: true,

    // Show the title
    title: true,

    // Show the toolbar
    toolbar: true,

    // Show the tooltip with image ratio (percentage) when zoom in or zoom out
    tooltip: true,

    // Enable to move the image
    movable: true,

    // Enable to zoom the image
    zoomable: true,

    // Enable to rotate the image
    rotatable: true,

    // Enable to scale the image
    scalable: true,

    // Enable CSS3 Transition for some special elements
    transition: true,

    // Enable to request fullscreen when play
    fullscreen: true,

    // Enable keyboard support
    keyboard: true,

    // Define interval of each image when playing
    interval: 5000,

    // Min width of the viewer in inline mode
    minWidth: 200,

    // Min height of the viewer in inline mode
    minHeight: 100,

    // Define the ratio when zoom the image by wheeling mouse
    zoomRatio: 0.1,

    // Define the min ratio of the image when zoom out
    minZoomRatio: 0.01,

    // Define the max ratio of the image when zoom in
    maxZoomRatio: 100,

    // Define the CSS `z-index` value of viewer in modal mode.
    zIndex: 2015,

    // Define the CSS `z-index` value of viewer in inline mode.
    zIndexInline: 0,

    // Define where to get the original image URL for viewing
    // Type: String (an image attribute) or Function (should return an image URL)
    url: 'src',

    // Event shortcuts
    ready: null,
    show: null,
    shown: null,
    hide: null,
    hidden: null,
    view: null,
    viewed: null
};

var TEMPLATE = '<div class="viewer-container">' + '<div class="viewer-canvas"></div>' + '<div class="viewer-footer">' + '<div class="viewer-title"></div>' + '<ul class="viewer-toolbar">' + '<li role="button" class="viewer-zoom-in" data-action="zoom-in"></li>' + '<li role="button" class="viewer-zoom-out" data-action="zoom-out"></li>' + '<li role="button" class="viewer-one-to-one" data-action="one-to-one"></li>' + '<li role="button" class="viewer-reset" data-action="reset"></li>' + '<li role="button" class="viewer-prev" data-action="prev"></li>' + '<li role="button" class="viewer-play" data-action="play"></li>' + '<li role="button" class="viewer-next" data-action="next"></li>' + '<li role="button" class="viewer-rotate-left" data-action="rotate-left"></li>' + '<li role="button" class="viewer-rotate-right" data-action="rotate-right"></li>' + '<li role="button" class="viewer-flip-horizontal" data-action="flip-horizontal"></li>' + '<li role="button" class="viewer-flip-vertical" data-action="flip-vertical"></li>' + '</ul>' + '<div class="viewer-navbar">' + '<ul class="viewer-list"></ul>' + '</div>' + '</div>' + '<div class="viewer-tooltip"></div>' + '<div role="button" class="viewer-button" data-action="mix"></div>' + '<div class="viewer-player"></div>' + '</div>';

var _window = window;
var PointerEvent = _window.PointerEvent;


var NAMESPACE = 'viewer';

// Actions
var ACTION_MOVE = 'move';
var ACTION_SWITCH = 'switch';
var ACTION_ZOOM = 'zoom';

// Classes
var CLASS_ACTIVE = NAMESPACE + '-active';
var CLASS_CLOSE = NAMESPACE + '-close';
var CLASS_FADE = NAMESPACE + '-fade';
var CLASS_FIXED = NAMESPACE + '-fixed';
var CLASS_FULLSCREEN = NAMESPACE + '-fullscreen';
var CLASS_FULLSCREEN_EXIT = NAMESPACE + '-fullscreen-exit';
var CLASS_HIDE = NAMESPACE + '-hide';
var CLASS_HIDE_MD_DOWN = NAMESPACE + '-hide-md-down';
var CLASS_HIDE_SM_DOWN = NAMESPACE + '-hide-sm-down';
var CLASS_HIDE_XS_DOWN = NAMESPACE + '-hide-xs-down';
var CLASS_IN = NAMESPACE + '-in';
var CLASS_INVISIBLE = NAMESPACE + '-invisible';
var CLASS_MOVE = NAMESPACE + '-move';
var CLASS_OPEN = NAMESPACE + '-open';
var CLASS_SHOW = NAMESPACE + '-show';
var CLASS_TRANSITION = NAMESPACE + '-transition';

// Events
var EVENT_READY = 'ready';
var EVENT_SHOW = 'show';
var EVENT_SHOWN = 'shown';
var EVENT_HIDE = 'hide';
var EVENT_HIDDEN = 'hidden';
var EVENT_VIEW = 'view';
var EVENT_VIEWED = 'viewed';
var EVENT_CLICK = 'click';
var EVENT_DRAG_START = 'dragstart';
var EVENT_KEY_DOWN = 'keydown';
var EVENT_LOAD = 'load';
var EVENT_POINTER_DOWN = PointerEvent ? 'pointerdown' : 'touchstart mousedown';
var EVENT_POINTER_MOVE = PointerEvent ? 'pointermove' : 'mousemove touchmove';
var EVENT_POINTER_UP = PointerEvent ? 'pointerup pointercancel' : 'touchend touchcancel mouseup';
var EVENT_RESIZE = 'resize';
var EVENT_TRANSITIONEND = 'transitionend';
var EVENT_WHEEL = 'wheel mousewheel DOMMouseScroll';

/**
 * Check if the given value is a string.
 * @param {*} value - The value to check.
 * @returns {boolean} Returns `true` if the given value is a string, else `false`.
 */
function isString(value) {
    return typeof value === 'string';
}

/**
 * Check if the given value is not a number.
 */
var isNaN = Number.isNaN || window.isNaN;

/**
 * Check if the given value is a number.
 * @param {*} value - The value to check.
 * @returns {boolean} Returns `true` if the given value is a number, else `false`.
 */
function isNumber(value) {
    return typeof value === 'number' && !isNaN(value)
}