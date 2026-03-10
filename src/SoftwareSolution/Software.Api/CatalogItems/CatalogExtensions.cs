using Software.Api.CatalogItems.Operations;

namespace Software.Api.CatalogItems;

public static class CatalogExtensions
{

   extension(IEndpointRouteBuilder builder)
    {
        public IEndpointRouteBuilder MapCatalogItemRoutes()
        {
            // TODO: Contemplate Groups.
            var vendorGroup = builder.MapGroup("/vendors").RequireAuthorization();

            vendorGroup.MapPost("/{vendorId:guid}/catalog-items", AddCatalogItem.AddCatalogItemAsync)
                .RequireAuthorization("SoftwareCenter").AddEndpointFilter<VendorExistsEndpointFilter>();


            vendorGroup.MapGet("/{vendorId:guid}/catalog-items", GetCatalogItemsByVendor.HandleAsync)
                .AddEndpointFilter<VendorExistsEndpointFilter>();

            vendorGroup.MapDelete("/{vendorId:guid}/catalog-items/{itemId:guid}", DeprecateCatalogItem.HandleAsync)
                .RequireAuthorization("SoftwareCenter")
                .AddEndpointFilter<VendorExistsEndpointFilter>();

            builder.MapGet("/catalog", GetAllCatalogItems.HandleAsync).RequireAuthorization();

            return builder;
        }
    }
}
