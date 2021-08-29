use actix_web::{web,App,HttpResponse,HttpServer,Responder};

async fn index() -> impl Responder{
    HttpResponse::Ok().body("Hello, World!")
}

async fn index2() -> impl Responder{
    HttpResponse::Ok().json("{\"message\":\"Hello world again!\"}")
}

#[actix_rt::main]
async fn main() -> std::io::Result<()>{
    HttpServer::new(||{
        App::new()
            .route("/", web::get().to(index))
            .route("/again",web::get().to(index2))
    })
    .bind("127.0.0.1:8008")?
    .run()
    .await
}
