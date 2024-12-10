package com.ganimedes.ganimedes_authentication_service.controllers;

import com.ganimedes.ganimedes_authentication_service.model.Login;
import com.ganimedes.ganimedes_authentication_service.model.Token;
import com.ganimedes.ganimedes_authentication_service.model.Usuario;
import com.ganimedes.ganimedes_authentication_service.repository.UsuarioRepository;
import com.ganimedes.ganimedes_authentication_service.repository.TokenRepository;
import com.ganimedes.ganimedes_authentication_service.services.JwtTokenService;
import jakarta.annotation.Resource;
import org.hibernate.service.spi.InjectService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@CrossOrigin(origins = "*")
@RestController
public class AuthenticationController {

    @Autowired
    UsuarioRepository loginRepository;

    @Autowired
    TokenRepository tokenRepository;

    @Autowired
    JwtTokenService jwtTokenService;

    @PostMapping("/authenticate")
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



}
