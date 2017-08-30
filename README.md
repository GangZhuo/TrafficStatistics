# TrafficStatistics

[![Build Status]][Appveyor]

### Screenshot


### Usage

* Relay TCP traffic from 127.0.0.1:5210 to 127.0.0.1:5211, and statistics traffic

    See blow screenshot. After click the "Start" button, program listen on "Left" (127.0.0.1:5210), and relay traffic to "Right" (127.0.0.1:5211), and renderer a chart for real-time traffic.
    
![Screenshot]

* Relay UDP traffic from 127.0.0.1:5210 to 127.0.0.1:5211, and statistics traffic

    Same TCP, but select UDP "Type".

[Appveyor]: https://ci.appveyor.com/project/GangZhuo/TrafficStatistics/branch/master
[Build Status]: https://ci.appveyor.com/api/projects/status/j81h4nforlmym2n5?svg=true
[Screenshot]: https://github.com/GangZhuo/TrafficStatistics/raw/master/screenshot.jpg
