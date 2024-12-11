package com.ganimedes.ganimedes_authentication_service.model;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;

import java.time.ZonedDateTime;

@Entity
public class Token {

    @Id
    private String token;

    @Column
    private ZonedDateTime expiresAt;

    @Column
    private String nUsp;

    public Token() {}

    public Token(String token, ZonedDateTime expiresAt, String nUsp) {
        this.token = token;
        this.expiresAt = expiresAt;
        this.nUsp = nUsp;
    }

    public String getToken() {
        return token;
    }

    public ZonedDateTime getExpiresAt() {
        return expiresAt;
    }

    public String getnUsp() {
        return nUsp;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public void setExpiresAt(ZonedDateTime expiresAt) {
        this.expiresAt = expiresAt;
    }

    public void setnUsp(String nUsp) {
        this.nUsp = nUsp;
    }
}
