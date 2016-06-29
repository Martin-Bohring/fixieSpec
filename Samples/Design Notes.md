# Media Domain Entities, Aggregates and Responsibilities

## Entities
- **Activties**  
  An activity has a certain lifetime (The duration of the activity itself)
  It requires a set of devices to fulfill its task (Different devices for different types of activities)
  Activities represent use cases (but use case is to overloaded as name IMHO).
  An activity is also an aggregate root.
  
- **Devices**  
  Devices maintain their own state. Devices can be disconnected and therefore are not available for use cases.
  Devices have a role within an activity (e.g. a microphone during audio recording or a speaker during playback).
  Some devices can be part of multiple activities at the same time. The device knows how to deal with that?
  (e.g playback on a speaker and the phone rings. Either playback is suspended or both sounds are mixed)

### Devices
- **Microphone**  
  A microphone can produce an audio stream from sound. In the sample domain we don't record music, therefore it is always human speech
  or environmental noise that is recorded.

- **VideoCamera**  
  A video camera can produce a video stream. That stream can be used to record videos or pictures

- **Speaker**  
  A speaker produces sound from an audio stream.

- **Headphone**  
  A headphone is a combination of a speaker and a microphone.

- **MediaRecorder**  
  A media recorder can record a video stream and an audio stream into a file or other permanent storage.

- **MediaPlayer**  
  A media player can turn recorded video or audio into a video or audio stream. Recorded video with sound will produce a video and an audio stream.

### Activities
- AudioRecording
- VideoRecording
- Call
- MediaPlayback
- AudioAlert
- AudioPrompt

### Topology
- RouteFinder?
- VideoMatrix
- AudioMatrix
- AudioMixer
- VideoInput
- VideoOutput
- AudioInput
- AudioOutput
- VideoRoute
- AudioRoute
