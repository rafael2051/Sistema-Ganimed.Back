package com.ganimedes.ganimedes_authentication_service.model;

import com.ganimedes.ganimedes_authentication_service.model.enums.TipoUsuario;
import jakarta.persistence.*;
import java.time.LocalDate;

@Entity
@Table(name = "usuario")
public class Usuario {

    @Id
    @Column(name = "nusp", nullable = false, unique = true)
    private String nUsp;

    @Column(name = "nome", nullable = false)
    private String nome;

    @Column(name = "email", nullable = false, unique = true)
    private String email;

    @Column(name = "password", nullable = false)
    private String password;

    @Column(name = "link_lattes")
    private String linkLattes;

    @Column(name = "dt_atualizacao_lattes")
    private LocalDate dtAtualizacaoLattes;

    @Column(name = "perfil", nullable = false)
    private String tipoUsuario;

    public String getNUsp() {
        return nUsp;
    }

    public void setNUsp(String nUsp) {
        this.nUsp = nUsp;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getLinkLattes() {
        return linkLattes;
    }

    public void setLinkLattes(String linkLattes) {
        this.linkLattes = linkLattes;
    }

    public LocalDate getDtAtualizacaoLattes() {
        return dtAtualizacaoLattes;
    }

    public void setDtAtualizacaoLattes(LocalDate dtAtualizacaoLattes) {
        this.dtAtualizacaoLattes = dtAtualizacaoLattes;
    }

    public String getTipoUsuario() {
        return tipoUsuario;
    }

    public void setTipoUsuario(String tipoUsuario) {
        this.tipoUsuario = tipoUsuario;
    }
}

