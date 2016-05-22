# About the Sample #
This is a different sample then you are used to.

## Why Audio Video ##
I am sick of all the bank account and calculator samples.
Therefore I was looking for something different that still allows to test drive fixieSpec.

Think about your Smartphone. What can it do for you. A lot it seems:

- Answering and making phone calls (really, I didn't know my phone can do that)
- Answering and making video calls using different apps
- Taking pictures
- Recording videos
- Voice recording
- Playing music
- Playing recorded or downloaded videos
- Playing recorded voice
- All of that using the headset or the speaker and a microphone.

Another example of the same domain could be a sophisticated living room.
You have your TV set, your surround system, maybe a room microphone, a webcam etc.

## What is specified using fixieSpec ##
All of those uses cases above are competing for the same resources (devices?) like:

- Speakers
- Microphones
- Cameras

Some of them are used exclusivly by a use case, some can be shared.
Some deal with life media types (low latency, minimal buffering),
some use recorded media types (extensive buffering less of a problem)

So most people know the domain and it is complex enough to serve as an example, but not too complex.

The following use cases are used as an example:

### Voice Phone calls ###
- Answer a voice phone call in headphone mode (using the builtin headset)
- Making a voice phone call in headphone mode
- Rejecting a voice phone call
- Answer a voice phone call in speaker phone mode (using the builtin speaker and microphone)
- Making a voice phone call in speaker phone mode
- Making a voice phone call that is rejected by the callee.

### Media recording ###
- Recording a video
- Taking a picture
- Recording a voice memo

### Playing music ###
- Playing music on a headset (external device that may or might not be present)
- Paying music on the internal speaker 
- Playing music on an external speaker (also external device that may or might not be present)

### Media playback ###
- Playing a recorded video
- Playing a recorded voice memo
- Resuming playback after taking or making a phone call







