package com.ganimedes.ganimedes_authentication_service.model;

public record ValidationResponse(
        String message,
        String tokenStatus
) {
}