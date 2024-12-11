package com.ganimedes.ganimedes_authentication_service.controllers;

import com.auth0.jwt.exceptions.JWTVerificationException;
import com.ganimedes.ganimedes_authentication_service.model.Login;
import com.ganimedes.ganimedes_authentication_service.model.Token;
import com.ganimedes.ganimedes_authentication_service.model.Usuario;
import com.ganimedes.ganimedes_authentication_service.model.ValidationResponse;
import com.ganimedes.ganimedes_authentication_service.repository.UsuarioRepository;
import com.ganimedes.ganimedes_authentication_service.services.JwtTokenService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@CrossOrigin(origins = "*")
@RestController
public class AuthenticationController {

    @Autowired
    UsuarioRepository loginRepository;

    @Autowired
    JwtTokenService jwtTokenService;

    @CrossOrigin(origins = "https://localhost:7260")
    @PostMapping(value = "/authenticate", consumes = "application/json")
    public ResponseEntity<Token> authenticate(@RequestBody Login login) {

        Optional<Usuario> usuarioOpt =
                loginRepository.findByEmailAndPassword(login.getUsername(), login.getPassword());

        if(!usuarioOpt.isPresent()) {
            return new ResponseEntity<>(null, HttpStatus.NOT_FOUND);
        }

        Usuario usuario = usuarioOpt.get();

        Token token = jwtTokenService.generateToken(usuario);

        return new ResponseEntity<>(token, HttpStatus.ACCEPTED);

    }

    @GetMapping("/validateToken/{nUsp}")
    public ResponseEntity<ValidationResponse> validateToken(@RequestHeader("Authorization") String token,
                                               @PathVariable String nUsp) {

        try{
            String nUspFromToken = jwtTokenService.getSubjectFromToken(token);

            if(!nUsp.equals(nUspFromToken)) {
                return new ResponseEntity<>(new ValidationResponse(
                        "O número USP fornecido não é o mesmo do token!",
                        "INVALID_ID"
                ), HttpStatus.UNAUTHORIZED);
            }

            return new ResponseEntity<>(
                    new ValidationResponse(
                            "Autenticação bem sucedida!",
                            "AUTHENTICATED"
                    ), HttpStatus.ACCEPTED);


        } catch(JWTVerificationException e) {
            return new ResponseEntity<>(new ValidationResponse(
                    "O token expirou!",
                    "INVALID_TOKEN"
            ), HttpStatus.UNAUTHORIZED);
        }

    }



}
