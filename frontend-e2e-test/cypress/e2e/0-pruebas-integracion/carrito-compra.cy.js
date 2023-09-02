describe("CRUD CarritoCompra", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:8100"); //Frontend de Produccion
    });

    //Servicio API - GetCategoriaProducto()
    it("GetCarritoCompra()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(3).click(); // click en el TAB de CategoriaProducto
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    //Servicio API - AddCategoriaProducto(entidad)
    it("AddCarritoCompra(entidad)", () => {
        cy.get("ion-tab-button").eq(3).click(); // click en el TAB de CategoriaProducto
        cy.wait(1000);//Esperar 1 seg.

        cy.get("#fecha")
            .type("insertar fecha cypress", { delay: 100 })
            .should("have.value", "insertar fecha cypress");

        cy.wait(500);//Esperar medio seg.

        cy.get("#idUsuarios")
            .type("insertar idUsuarios cypress", { delay: 100 })
            .should("have.value", "insertar idUsuarios cypres s");

        cy.wait(500);//Esperar medio seg.

        cy.get("#addCarritoCompra").not("[disabled]").click();
    });
});