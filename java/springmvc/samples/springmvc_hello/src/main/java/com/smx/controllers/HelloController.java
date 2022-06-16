package com.smx.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author smx
 * @create 2022-06-14 22:25
 */
@RestController
public class HelloController {

    @GetMapping("/hello")
    public String hello() {
        return "hello spring mvc!";
    }
}
