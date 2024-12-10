package com.ganimedes.ganimedes_authentication_service.services;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.exceptions.JWTCreationException;
import com.auth0.jwt.exceptions.JWTVerificationException;
import com.ganimedes.ganimedes_authentication_service.model.Token;
import com.ganimedes.ganimedes_authentication_service.model.Usuario;
import org.springframework.stereotype.Service;

import java.time.*;

@Service
public class JwtTokenService {

    private static final String SECRET_KEY = "4Z^XrroxR@dWxqf$mTTKwW$!@#qGr4P";

    private static final String ISSUER = "ganimedes"; // Emissor do token

    public Token generateToken(Usuario usuario) {
        try {

            Algorithm algorithm = Algorithm.HMAC256(SECRET_KEY);

            Token token = new Token();

            Instant creationDate = creationDate();

            Instant expirationDate = expirationDate();

            token.setToken(
                    JWT.create()
                            .withIssuer(ISSUER)
                            .withIssuedAt(creationDate)
                            .withExpiresAt(expirationDate)
                            .withSubject(usuario.getNUsp())
                            .sign(algorithm)
            );

            token.setnUsp(usuario.getNUsp());

            ZoneId zone = ZoneId.of("America/Sao_Paulo");

            token.setExpiresAt(expirationDate.atZone(zone));

            return token;

        } catch (JWTCreationException exception){
            throw new JWTCreationException("Erro ao gerar token.", exception);
        }
    }

    public String getSubjectFromToken(String token) {
        try {

            Algorithm algorithm = Algorithm.HMAC256(SECRET_KEY);
            return JWT.require(algorithm)
                    .withIssuer(ISSUER)
                    .build()
                    .verify(token)
                    .getSubject();
        } catch (JWTVerificationException exception){
            throw new JWTVerificationException("Token inválido ou expirado.");
        }
    }

    private Instant creationDate() {
        return ZonedDateTime.now(ZoneId.of("America/Sao_Paulo")).toInstant();
    }

    private Instant expirationDate() {
        return ZonedDateTime.now(ZoneId.of("America/Sao_Paulo")).plusHours(4).toInstant();
    }

}
