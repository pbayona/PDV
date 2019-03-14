#pragma strict

var killSource: AudioSource;
var shootSource: AudioSource;
var explosionSource: AudioSource;

static var kill : AudioSource;
static var shoot : AudioSource;
static var explosion : AudioSource;

function Start () {
	kill=killSource;
    shoot=shootSource;
    explosion=explosionSource;
}

function Update () {
	
}

static function PlayKill(){
    kill.Play(0);
}

static function PlayShoot(){
    shoot.Play(0);
}

static function PlayExplosion(){
    explosion.Play(0);
}
